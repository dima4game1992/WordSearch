using System.Collections.Generic;
using WordSearch.Data;

namespace WordSearch
{
    public sealed class GridGenerator : IGridGenerator
    {
        private readonly IGameFactory _gameFactory;

        public GridGenerator(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public GridView Generate(Level level)
        {
            var sizeY = level.grid.Count;
            var sizeX = level.grid[0].Count;

            IEnumerable<RowView> rows = CreateRowViews();
            return _gameFactory.CreateGridView(rows);

            IEnumerable<RowView> CreateRowViews()
            {
                for (var y = 0; y < sizeY; y++)
                {
                    IEnumerable<LetterView> letters = CreateLetters(y);
                    yield return _gameFactory.CreateRowView(letters);
                }

                IEnumerable<LetterView> CreateLetters(int y)
                {
                    for (var x = 0; x < sizeX; x++)
                    {
                        var letter = GetLetter(y, x);
                        yield return _gameFactory.CreateLetterView(letter);
                    }

                    string GetLetter(int row, int column) =>
                        level.grid[row][column];
                }
            }
        }
    }
}