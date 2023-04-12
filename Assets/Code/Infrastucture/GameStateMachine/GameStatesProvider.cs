using System;
using System.Collections.Generic;

namespace WordSearch
{
    public class GameStatesProvider : IStatesProvider
    {
        private Dictionary<Type, IExitableState> States { get; } = new();

        public TState GetState<TState>() where TState : class, IExitableState =>
            States[typeof(TState)] as TState;

        public GameStatesProvider AddState(IExitableState state)
        {
            States.TryAdd(state.GetType(), state);
            return this;
        }
    }
}