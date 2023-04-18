using WordSearch.Data.Interfaces;

namespace WordSearch.Data
{
    public class LevelsProvider : ILevelsProvider
    {
        public LevelsData LevelsData { get; set; }
    }
}