using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace WordSearch.UI.Grid
{
    public class GridView : MonoBehaviour
    {
        private IReadOnlyList<RowView> _rows;

        [Inject]
        private void Construct(IEnumerable<RowView> rows)
        {
            _rows = rows.ToList();
        }

        private void Awake()
        {
            SetRows(_rows);
        }

        public LetterView GetLetterByPosition(Vector2Int letterPosition)
        {
            return _rows
                .SelectMany(row => row.LetterViews)
                .FirstOrDefault(letter => letter.LetterPosition == new Vector2Int(letterPosition.y, letterPosition.x));
                // .FirstOrDefault(letter => letter.LetterPosition == letterPosition);
        }

        private void SetRows(IEnumerable<RowView> rows)
        {
            foreach (RowView row in rows)
                row.transform.parent = transform;
        }
        
        public class Factory : PlaceholderFactory<IEnumerable<RowView>, GridView> { }
    }
}