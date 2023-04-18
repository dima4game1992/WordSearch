using System.Collections.Generic;
using UnityEngine;
using WordSearch.UI.Grid;

namespace WordSearch
{
    public interface IGameFactory
    {
        GridView CreateGridView(IEnumerable<RowView> rowViews);
        RowView CreateRowView(IEnumerable<LetterView> letters);
        LetterView CreateLetterView(string letter, Vector2Int letterPosition);
    }
}