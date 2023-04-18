using System.Collections.Generic;
using UnityEngine;
using WordSearch.UI.Grid;

namespace WordSearch
{
    public sealed class GameFactory : IGameFactory
    {
        private readonly GridView.Factory _gridViewFactory;
        private readonly RowView.Factory _rowViewFactory;
        private readonly LetterView.Factory _letterViewFactory;

        public GameFactory(GridView.Factory gridViewFactory, RowView.Factory rowViewFactory, LetterView.Factory letterViewFactory)
        {
            _gridViewFactory = gridViewFactory;
            _rowViewFactory = rowViewFactory;
            _letterViewFactory = letterViewFactory;
        }

        public GridView CreateGridView(IEnumerable<RowView> rowViews)
        {
            return _gridViewFactory.Create(rowViews);
        }

        public RowView CreateRowView(IEnumerable<LetterView> letters)
        {
            return _rowViewFactory.Create(letters);
        }

        public LetterView CreateLetterView(string letter, Vector2Int letterPosition)
        {
            return _letterViewFactory.Create(letter, letterPosition);
        }
    }
}