using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace WordSearch
{
    public class Row : IRow
    {
        public Row(IEnumerable<ILetter> letters)
        {
            Letters = letters.ToList();
            Value = string.Join("", Letters.Select(letter => letter.Value));
        }

        public string Value { get; }
        public IReadOnlyList<ILetter> Letters { get; }
    }
}