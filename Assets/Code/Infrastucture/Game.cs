using System;

namespace WordSearch
{
    public class Game : IDisposable
    {
        public readonly GameStateMachine GameStateMachine;

        public Game(GameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }

        public void Dispose() => GameStateMachine?.DisposeAsync();
    }
}