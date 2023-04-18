using System.Threading;
using System.Threading.Tasks;
using WordSearch.Data;

namespace WordSearch
{
    public sealed class LoadNextLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly CurrentLevelProvider _currentLevelProvider;

        public LoadNextLevelState(GameStateMachine stateMachine, ISceneLoader sceneLoader, CurrentLevelProvider currentLevelProvider)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _currentLevelProvider = currentLevelProvider;
        }

        public async Task Enter(CancellationToken token)
        {
            _currentLevelProvider.SetNextLevel();
            await _sceneLoader.LoadSceneAsync(Scene.Game, true, token);
            _stateMachine.Enter<GameLoopState>();
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}