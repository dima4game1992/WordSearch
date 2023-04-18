using System.Collections;
using UnityEngine;
using WordSearch.UI.Grid;
using Zenject;

namespace WordSearch
{
    [RequireComponent(typeof(RectTransform))]
    public class ShakingRectTransform : MonoBehaviour
    {
        private RectTransform _rectTransformCached;
        private Vector3 _originalPosition;
        private Coroutine _shakingCoroutine;

        private RectTransform RectTransform =>
            _rectTransformCached != null 
                ? _rectTransformCached 
                : _rectTransformCached = transform as RectTransform;

        private ShakingAnimationSettings _animationSettings;

        [Inject]
        private void Construct(ShakingAnimationSettings animationSettings)
        {
            _animationSettings = animationSettings;
            _originalPosition = RectTransform.anchoredPosition;
        }

        public void Run()
        {
            if (_shakingCoroutine != null)
            {
                StopCoroutine(_shakingCoroutine);
                RectTransform.anchoredPosition = _originalPosition;
            }

            _shakingCoroutine = StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            var shakeTimer = _animationSettings.ShakeDuration;

            while (shakeTimer > 0f)
            {
                RectTransform.anchoredPosition = _originalPosition + Random.insideUnitSphere * _animationSettings.ShakeIntensity;
                shakeTimer -= Time.deltaTime;
                yield return null;
            }

            RectTransform.anchoredPosition = _originalPosition;
            _shakingCoroutine = null;
        }
    }
}