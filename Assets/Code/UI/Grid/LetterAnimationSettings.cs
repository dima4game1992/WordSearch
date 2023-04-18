using UnityEngine;

namespace WordSearch.UI.Grid
{
    [CreateAssetMenu(menuName = "WordSearch/Create LetterAnimationSettings", fileName = "LetterAnimationSettings", order = 0)]
    public class LetterAnimationSettings : ScriptableObject
    {
        [SerializeField] private float _openingTime;

        public float OpeningTime => _openingTime;
    }
}