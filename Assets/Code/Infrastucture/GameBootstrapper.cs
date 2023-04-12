using System.Collections.Generic;
using Zenject;

namespace WordSearch
{
    public sealed class GameBootstrapper : IInitializable
    {
        private readonly Game _game;
        private readonly GameStatesProvider _gameStatesProvider;
        private readonly IEnumerable<IExitableState> _states;

        public GameBootstrapper(Game game, GameStatesProvider gameStatesProvider, IEnumerable<IExitableState> states)
        {
            _game = game;
            _gameStatesProvider = gameStatesProvider;
            _states = states;
        }

        public void Initialize()
        {
            RegisterStates();
            EnterBootstrapState();
        }

        private void RegisterStates()
        {
            foreach (IExitableState state in _states) 
                _gameStatesProvider.AddState(state);
        }

        private void EnterBootstrapState()
        {
            _game.GameStateMachine.Enter<BootstrapState>();
        }
    }
}