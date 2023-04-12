using Zenject;

namespace WordSearch
{
    public class GameBootstrapper : IInitializable
    {
        private readonly Game _game;
        private readonly GameStatesProvider _gameStatesProvider;
        private readonly ISceneLoader _sceneLoader;

        public GameBootstrapper(Game game, GameStatesProvider gameStatesProvider, ISceneLoader sceneLoader)
        {
            _game = game;
            _gameStatesProvider = gameStatesProvider;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            RegisterStates();
            EnterBootstrapState();
        }

        private void RegisterStates()
        {
            _gameStatesProvider
                .AddState(new BootstrapState(_game.GameStateMachine, _sceneLoader))
                .AddState(new LoadLevelState(_game.GameStateMachine, _sceneLoader))
                .AddState(new GameLoopState());
        }

        private void EnterBootstrapState()
        {
            _game.GameStateMachine.Enter<BootstrapState>();
        }
    }
}