using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async Task Enter(CancellationToken token)
        {
            await _sceneLoader.LoadSceneAsync(Scene.Bootstrap, token);
            _stateMachine.Enter<LoadSceneState, Scene>(Scene.Game);
        }

        public Task Exit(CancellationToken token) => Task.CompletedTask;
    }
}