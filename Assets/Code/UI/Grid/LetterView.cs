using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace WordSearch.UI.Grid
{
    public class LetterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private CanvasGroup _canvasGroup;

        private LetterAnimationSettings _animationSettings;

        [Inject]
        private void Construct(LetterAnimationSettings animationSettings, string letter, Vector2Int letterPosition)
        {
            LetterPosition = letterPosition;
            _animationSettings = animationSettings;
            _tmpText.text = letter;
            _canvasGroup.alpha = 0f;
        }

        public Vector2Int LetterPosition { get; private set; }

        public IEnumerator OpenCoroutine()
        {
            var openingTime = _animationSettings.OpeningTime;
            var time = 0f;
            while (time < openingTime)
            {
                var alpha = Mathf.Lerp(0, 1, time / openingTime);
                _canvasGroup.alpha = alpha;
                yield return null;
                time += Time.deltaTime;
            }

            _canvasGroup.alpha = 1f;
        }

        public class Factory : PlaceholderFactory<string, Vector2Int, LetterView> { }
    }
}