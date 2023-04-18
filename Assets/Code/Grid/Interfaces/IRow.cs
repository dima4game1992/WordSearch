using System.Collections.Generic;

namespace WordSearch
{
    public interface IRow
    {
        string Value { get; }
        IReadOnlyList<ILetter> Letters { get; }
    }
}