using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public sealed class GridGenerator : IGridGenerator
    {
        public IGrid Generate(string[][] gridData, IEnumerable<string> wordsData)
        {
            var sizeY = gridData.Length;
            var sizeX = gridData[0].Length;

            IEnumerable<Row> rows = CreateRowViews().ToList();
            IEnumerable<IWord> words = CreateWords().ToList();
            return new Grid(gridData, rows, words);

            IEnumerable<IWord> CreateWords() =>
                wordsData.Select(word => new Word(word));

            IEnumerable<Row> CreateRowViews()
            {
                for (var y = 0; y < sizeY; y++)
                {
                    IEnumerable<Letter> letters = CreateLetters(y).ToList();
                    yield return new Row(letters);
                }

                IEnumerable<Letter> CreateLetters(int y)
                {
                    for (var x = 0; x < sizeX; x++)
                    {
                        var letter = GetLetter(y, x);
                        yield return new Letter(letter, new LetterPosition(y, x));
                    }

                    string GetLetter(int row, int column) =>
                        gridData[row][column];
                }
            }
        }
    }
}