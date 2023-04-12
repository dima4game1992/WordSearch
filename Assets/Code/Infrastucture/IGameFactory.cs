using System.Collections.Generic;

namespace WordSearch
{
    public interface IGameFactory
    {
        GridView CreateGridView(IEnumerable<RowView> rowViews);
        LetterView CreateLetterView(string letter);
        RowView CreateRowView(IEnumerable<LetterView> letters);
    }
}