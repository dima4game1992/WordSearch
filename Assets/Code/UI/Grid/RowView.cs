using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace WordSearch.UI.Grid
{
    public class RowView : MonoBehaviour
    {
        private IReadOnlyList<LetterView> _letterViews;

        public IReadOnlyList<LetterView> LetterViews => _letterViews;

        [Inject]
        private void Construct(IEnumerable<LetterView> letterViews)
        {
            _letterViews = letterViews.ToList();
        }

        private void Awake()
        {
            SetLetters(_letterViews);
        }

        private void SetLetters(IEnumerable<LetterView> letters)
        {
            foreach (LetterView letter in letters) 
                letter.transform.parent = transform;
        }
        
        public class Factory : PlaceholderFactory<IEnumerable<LetterView>, RowView> { }
    }
}