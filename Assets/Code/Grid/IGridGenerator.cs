using System.Collections.Generic;

namespace WordSearch
{
    public interface IGridGenerator
    {
        IGrid Generate(string[][] gridData, IEnumerable<string> wordsData);
    }
}