using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WordSearch.UI.Grid.Interfaces;

namespace WordSearch.UI.Grid
{
    public sealed class GridViewGenerator : IGridViewGenerator
    {
        private readonly IGameFactory _gameFactory;

        public GridViewGenerator(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public GridView Generate(string[][] grid)
        {
            var sizeY = grid.Length;
            var sizeX = grid[0].Length;

            IEnumerable<RowView> rows = CreateRowViews().ToList();
            return _gameFactory.CreateGridView(rows);

            IEnumerable<RowView> CreateRowViews()
            {
                for (var y = 0; y < sizeY; y++)
                {
                    IEnumerable<LetterView> letters = CreateLetters(y).ToList();
                    yield return _gameFactory.CreateRowView(letters);
                }

                IEnumerable<LetterView> CreateLetters(int y)
                {
                    for (var x = 0; x < sizeX; x++)
                    {
                        var letter = GetLetter(y, x);
                        yield return _gameFactory.CreateLetterView(letter, new Vector2Int(x, y));
                    }

                    string GetLetter(int row, int column) =>
                        grid[row][column];
                }
            }
        }
    }
}