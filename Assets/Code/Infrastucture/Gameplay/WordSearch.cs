using UnityEngine;

namespace WordSearch
{
    public class WordSearch
    {
        private string[][] grid; // сетка из букв
        private bool[][] visited; // матрица для отметки посещенных ячеек

        // конструктор, принимающий сетку из букв
        public WordSearch(string[][] grid)
        {
            this.grid = grid;
            this.visited = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                visited[i] = new bool[grid[0].Length];
            }
        }

        // метод поиска слова на сетке
        public bool SearchWord(string word, out Vector2Int[] indexes)
        {
            indexes = new Vector2Int[word.Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (DFS(i, j, word, 0, indexes))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // метод обхода графа в глубину
        private bool DFS(int i, int j, string word, int index, Vector2Int[] indexes)
        {
            // если индекс выходит за пределы длины слова, значит слово найдено
            if (index == word.Length)
            {
                return true;
            }

            // если координаты ячейки выходят за пределы сетки, возвращаем false
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
            {
                return false;
            }

            // если ячейка уже была посещена или буква в ней не соответствует текущей букве из слова, возвращаем false
            if (visited[i][j] || grid[i][j] != word[index].ToString())
            {
                return false;
            }

            // отмечаем текущую ячейку как посещенную
            visited[i][j] = true;

            // добавляем индекс текущей ячейки в массив индексов
            indexes[index] = new Vector2Int(i, j);

            // рекурсивно ищем следующую букву слова в соседних ячейках
            bool result = DFS(i - 1, j, word, index + 1, indexes) ||
                          DFS(i + 1, j, word, index + 1, indexes) ||
                          DFS(i, j - 1, word, index + 1, indexes) ||
                          DFS(i, j + 1, word, index + 1, indexes);

            // снимаем отметку о посещении текущей ячейки перед возвратом из рекурсии
            visited[i][j] = false;

            if (!result)
            {
                // если слово не найдено, удаляем последний индекс из массива
                indexes[index] = default;
            }

            return result;
        }
    }
}