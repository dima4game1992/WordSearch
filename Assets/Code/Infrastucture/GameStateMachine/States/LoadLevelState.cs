using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public sealed class LoadLevelState : IPayloadedState<Scene>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async Task Enter(Scene scene, CancellationToken token)
        {
            await _sceneLoader.LoadSceneAsync(scene, token);
            _stateMachine.Enter<GameLoopState>();
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}