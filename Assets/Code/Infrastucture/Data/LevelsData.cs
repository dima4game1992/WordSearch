using System.Collections.Generic;

namespace WordSearch.Data
{
    public sealed record LevelsData
    {
        public List<LevelData> levels { get; set; }
    }
}