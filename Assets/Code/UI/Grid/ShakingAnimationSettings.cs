using UnityEngine;

namespace WordSearch.UI.Grid
{
    [CreateAssetMenu(menuName = "WordSearch/Create ShakingAnimationSettings", fileName = "ShakingAnimationSettings", order = 0)]
    public class ShakingAnimationSettings : ScriptableObject
    {
        [SerializeField] private float _shakeDuration = 0.5f;
        [SerializeField] private float _shakeIntensity = 1f;

        public float ShakeDuration => _shakeDuration;
        public float ShakeIntensity => _shakeIntensity;
    }
}