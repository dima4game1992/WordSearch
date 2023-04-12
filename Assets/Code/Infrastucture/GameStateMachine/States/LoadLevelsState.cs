using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using WordSearch.Data;

namespace WordSearch
{
    public sealed class LoadLevelsState : IState
    {
        private const string LevelIndex = "LevelIndex";
        private readonly GameStateMachine _stateMachine;
        private readonly ILevelsLoader _levelsLoader;
        private readonly LevelsProvider _levelsProvider;

        public LoadLevelsState(GameStateMachine stateMachine, ILevelsLoader levelsLoader, LevelsProvider levelsProvider)
        {
            _stateMachine = stateMachine;
            _levelsLoader = levelsLoader;
            _levelsProvider = levelsProvider;
        }

        public async Task Enter(CancellationToken token)
        {
            await RegisterLevels();
            _stateMachine.Enter<LoadLevelState, int>(LastLevelIndex);
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }

        private async Task RegisterLevels()
        {
            LevelsData levelsData = await _levelsLoader.LoadLevels();
#if UNITY_EDITOR
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(levelsData);
            Debug.Log($"Loaded levels {json}");
#endif
            _levelsProvider.LevelsData = levelsData;
        }

        private static int LastLevelIndex
        {
            get => PlayerPrefs.GetInt(LevelIndex, 0);
            set
            {
                PlayerPrefs.SetInt(LevelIndex, value);
                PlayerPrefs.Save();
            }
        }
    }
}