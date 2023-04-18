using System.Collections.Generic;

namespace WordSearch
{
    public interface IGrid
    {
        string[][] GridData { get; }
        IReadOnlyList<IRow> Rows { get; }
        IReadOnlyList<IWord> WordsToSearch { get; }
        bool IsCompleted { get; }
    }
}