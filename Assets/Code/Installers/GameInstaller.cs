using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WordSearch.AssetManagement;
using WordSearch.Data;
using WordSearch.Data.Interfaces;
using WordSearch.UI.Grid;
using WordSearch.UI.Grid.Interfaces;
using Zenject;

namespace WordSearch
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GridPlaceholder _gridPlaceholder;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _searchButton;
        [SerializeField] private Button _debugSearchButton;
        [SerializeField] private ShakingRectTransform _shakingRectTransform;
        [SerializeField] private AudioSource _audioSourceIncorrectInput;

        private IAssetProvider _assetProvider;
        private ICurrentLevelProvider _currentLevelProvider;

        [Inject]
        private void Construct(IAssetProvider assetProvider, ICurrentLevelProvider currentLevelProvider)
        {
            _assetProvider = assetProvider;
            _currentLevelProvider = currentLevelProvider;
        }
        
        public override void InstallBindings()
        {
            BindGameFactory();
            BindGameplay();
            BindGridFactories();
            BindGridPlaceholder();
            BindGridPresenterFactory();
            BindGridGenerator();
            BindGridViewGenerator();
            BindInputField();
            BindLevel();
            BindSearchButton();
            BindDebugSearchButton();
            BindCoroutineRunner();
            BindShakeAnimation();
            BindAudioSourceIncorrectInput();
        }

        private void BindAudioSourceIncorrectInput()
        {
            Container
                .Bind<AudioSource>()
                .FromInstance(_audioSourceIncorrectInput);
        }

        private void BindShakeAnimation()
        {
            Container
                .Bind<ShakingRectTransform>()
                .FromInstance(_shakingRectTransform);
        }

        private void BindCoroutineRunner()
        {
            Container
                .BindInterfacesTo<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindGridGenerator()
        {
            Container
                .Bind<IGridGenerator>()
                .To<GridGenerator>()
                .AsSingle();
        }

        private void BindSearchButton()
        {
            Container
                .Bind<Button>()
                .WithId(ButtonType.SearchButton)
                .FromInstance(_searchButton);
        }
        
        private void BindDebugSearchButton()
        {
            Container
                .Bind<Button>()
                .WithId(ButtonType.DebugSearchButton)
                .FromInstance(_debugSearchButton);
        }

        private void BindInputField()
        {
            Container
                .Bind<TMP_InputField>()
                .FromInstance(_inputField)
                .AsSingle();
        }

        private void BindGameplay()
        {
            Container
                .BindInterfacesAndSelfTo<Gameplay>()
                .AsSingle();
        }

        private void BindGridPlaceholder()
        {
            Container
                .Bind<GridPlaceholder>()
                .FromInstance(_gridPlaceholder)
                .AsSingle();
        }

        private void BindLevel()
        {
            Container
                .Bind<LevelData>()
                .FromInstance(_currentLevelProvider.Value)
                .AsSingle();
        }

        private void BindGridFactories()
        {
            var gridPrefab = _assetProvider.GetPrefab<GridView>(AssetPath.GridViewPath);
            var rowPrefab = _assetProvider.GetPrefab<RowView>(AssetPath.RowViewPath);
            var letterPrefab = _assetProvider.GetPrefab<LetterView>(AssetPath.LetterViewPath);

            Container
                .BindFactory<IEnumerable<RowView>, GridView, GridView.Factory>()
                .FromComponentInNewPrefab(gridPrefab);
            
            Container
                .BindFactory<IEnumerable<LetterView>, RowView, RowView.Factory>()
                .FromComponentInNewPrefab(rowPrefab);
            
            Container
                .BindFactory<string, Vector2Int, LetterView, LetterView.Factory>()
                .FromComponentInNewPrefab(letterPrefab);
        }

        private void BindGridViewGenerator()
        {
            Container
                .Bind<IGridViewGenerator>()
                .To<GridViewGenerator>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void BindGridPresenterFactory()
        {
            Container.BindFactory<IGrid, GridView, GridPresenter, GridPresenter.Factory>();
        }
    }
}