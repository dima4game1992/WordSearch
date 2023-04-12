using System.Threading;
using System.Threading.Tasks;
using WordSearch.Data;

namespace WordSearch
{
    public sealed class LoadLevelState : IPayloadedState<int>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ILevelsProvider _levelsProvider;
        private readonly IGridGenerator _gridGenerator;

        public LoadLevelState(GameStateMachine stateMachine, ILevelsProvider levelsProvider, IGridGenerator gridGenerator)
        {
            _stateMachine = stateMachine;
            _levelsProvider = levelsProvider;
            _gridGenerator = gridGenerator;
        }

        public async Task Enter(int levelIndex, CancellationToken token)
        {
            Level level = _levelsProvider.LevelsData.levels[levelIndex];
            GridView gridView = GenerateGrid(level);
            _stateMachine.Enter<GameLoopState>();
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }

        private GridView GenerateGrid(Level level)
        {
            return _gridGenerator.Generate(level);
        }
    }
}