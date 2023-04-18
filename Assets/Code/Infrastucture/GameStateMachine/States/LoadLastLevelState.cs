using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public sealed class LoadLastLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLastLevelState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async Task Enter(CancellationToken token)
        {
            await _sceneLoader.LoadSceneAsync(Scene.Game, false, token);
            _stateMachine.Enter<GameLoopState>();
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}