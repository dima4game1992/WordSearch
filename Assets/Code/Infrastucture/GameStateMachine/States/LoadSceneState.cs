using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public sealed class LoadSceneState : IPayloadedState<Scene>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadSceneState(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async Task Enter(Scene levelIndex, CancellationToken token)
        {
            await _sceneLoader.LoadSceneAsync(levelIndex, token);
            _stateMachine.Enter<LoadLevelsState>();
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}