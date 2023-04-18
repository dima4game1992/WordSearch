using UnityEngine;
using WordSearch.Data.Interfaces;

namespace WordSearch.Data
{
    public sealed class CurrentLevelProvider : ICurrentLevelProvider
    {
        private const string LevelIndexKey = "LevelIndex";

        private readonly ILevelsProvider _levelsProvider;

        public CurrentLevelProvider(ILevelsProvider levelsProvider)
        {
            _levelsProvider = levelsProvider;
        }

        public LevelData Value => _levelsProvider.LevelsData.levels[LastLevelIndex];
        public int LevelIndex => LastLevelIndex;

        public void SetNextLevel()
        {
            var newIndex = LastLevelIndex + 1;
            var levelsCount = _levelsProvider.LevelsData.levels.Count;
            newIndex %= levelsCount;
            LastLevelIndex = newIndex;
        }

        private static int LastLevelIndex
        {
            get => PlayerPrefs.GetInt(LevelIndexKey, 0);
            set
            {
                PlayerPrefs.SetInt(LevelIndexKey, value);
                PlayerPrefs.Save();
            }
        }
    }
}