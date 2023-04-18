using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using WordSearch.Data;
using WordSearch.Data.Interfaces;
using WordSearch.UI.Grid;
using Zenject;

namespace WordSearch
{
    public class GridPresenter : IInitializable, IDisposable
    {
        private readonly IGrid _grid;
        private readonly GridView _gridView;
        private readonly Button _searchButton;
        private readonly Button _debugSearchButton;
        private readonly TMP_InputField _inputField;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ICurrentLevelProvider _currentLevelProvider;
        private readonly ShakingRectTransform _shakingRectTransform;
        private readonly AudioSource _audioSourceIncorrectInput;
        private readonly GameStateMachine _gameStateMachine;
        private readonly CompositeDisposable _compositeDisposable;

        public GridPresenter(IGrid grid,
            GridView gridView,
            [Inject(Id = ButtonType.SearchButton)] Button searchButton,
            [Inject(Id = ButtonType.DebugSearchButton)]
            Button debugSearchButton,
            TMP_InputField inputField,
            ICoroutineRunner coroutineRunner,
            ICurrentLevelProvider currentLevelProvider,
            ShakingRectTransform shakingRectTransform,
            AudioSource audioSourceIncorrectInput,
            GameStateMachine gameStateMachine)
        {
            _shakingRectTransform = shakingRectTransform;
            _audioSourceIncorrectInput = audioSourceIncorrectInput;
            _gameStateMachine = gameStateMachine;
            _currentLevelProvider = currentLevelProvider;
            _grid = grid;
            _gridView = gridView;
            _searchButton = searchButton;
            _debugSearchButton = debugSearchButton;
            _inputField = inputField;
            _coroutineRunner = coroutineRunner;
            _compositeDisposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            SubscribeOnSearchButton();
#if DEBUG
            var onDebugSearchButtonClick = _debugSearchButton
                .OnClickAsObservable();

            var onSpaceKeyClick = Observable
                .EveryUpdate()
                .Where(_ => Input.GetKeyDown(KeyCode.Space));

            onSpaceKeyClick.Select(_ => Unit.Default)
                .Merge(onDebugSearchButtonClick)
                .Select(_ =>
                {
                    return _grid
                        .WordsToSearch
                        .FirstOrDefault(word => word.IsOpened == false);
                })
                .Where(word => word != null)
                .Subscribe(SearchWordInGridProcess)
                .AddTo(_compositeDisposable);
#endif
        }

        public void Dispose()
        {
            _searchButton
                .onClick
                .RemoveListener(OnSearchButtonClick);
            _compositeDisposable?.Dispose();
        }

        private void SubscribeOnSearchButton()
        {
            _searchButton
                .onClick
                .AddListener(OnSearchButtonClick);
        }

        private void OnSearchButtonClick()
        {
            var wordString = _inputField.text;
            SearchWord(wordString);
            ClearInputField();
        }

        private void SearchWord(string wordString)
        {
            IWord word = GetSearchedWordOrNull(wordString);

            if (word == null)
                IncorrectInput();
            else
                SearchWordInGridProcess(word);
        }

        private void SearchWordInGridProcess(IWord word)
        {
            var wordString = word.Value.ToUpper();
            var wordSearch = new WordSearch(_grid.GridData);
            if (wordSearch.SearchWord(wordString, out Vector2Int[] indexes))
            {
                IEnumerable<LetterView> letters = indexes.Select(index => _gridView.GetLetterByPosition(index));
                AnimateLetters(letters);
                word.IsOpened = true;
                if (_grid.IsCompleted)
                    _gameStateMachine.Enter<LoadNextLevelState>();
            }
        }

        private IWord GetSearchedWordOrNull(string wordString)
        {
            return _grid.WordsToSearch
                .SingleOrDefault(word => word.IsOpened == false && word.Value.Equals(wordString, StringComparison.InvariantCultureIgnoreCase));
        }

        private void IncorrectInput()
        {
            LevelData levelData = _currentLevelProvider.Value;
            switch (levelData.IncorrectInputBehaviour)
            {
                case IncorrectInputBehaviour.None:
                    break;
                case IncorrectInputBehaviour.Shaking:
                    ShakeInputField();
                    break;
                case IncorrectInputBehaviour.Sound:
                    PlayIncorrectSound();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PlayIncorrectSound() => _audioSourceIncorrectInput.Play();

        private void ShakeInputField() => _shakingRectTransform.Run();

        private void AnimateLetters(IEnumerable<LetterView> letters)
        {
            IEnumerable<IEnumerator> coroutines = letters.Select(letter => letter.OpenCoroutine());
            _coroutineRunner.StartCoroutines(coroutines);
        }

        private void ClearInputField() => _inputField.text = string.Empty;

        public class Factory : PlaceholderFactory<IGrid, GridView, GridPresenter> { }
    }
}