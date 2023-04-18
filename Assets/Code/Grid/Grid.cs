using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public sealed class Grid : IGrid
    {
        public Grid(string[][] gridData, IEnumerable<IRow> rows, IEnumerable<IWord> wordsToSearch)
        {
            GridData = gridData;
            Rows = rows.ToList();
            WordsToSearch = wordsToSearch.ToList();
        }

        public string[][] GridData { get; }
        public IReadOnlyList<IRow> Rows { get; }
        public IReadOnlyList<IWord> WordsToSearch { get; }
        public bool IsCompleted => WordsToSearch.All(word => word.IsOpened);
    }
}