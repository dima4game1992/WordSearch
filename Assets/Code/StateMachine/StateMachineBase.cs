using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace WordSearch
{
    public abstract class StateMachineBase : IAsyncDisposable
    {
        private readonly IStatesProvider _statesProvider;
        private CancellationTokenSource _cts = new();
        private IExitableState _currentState;

        protected StateMachineBase(IStatesProvider statesProvider) =>
            _statesProvider = statesProvider;

        public void Enter<TState>() where TState : class, IState
        {
            IState nextState = ChangeState<TState>();
            Debug.Log($"Enter state: {nextState}");
            nextState.Enter(_cts.Token);
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var nextState = ChangeState<TState>();
            Debug.Log($"Enter state: {nextState}");
            nextState.Enter(payload, _cts.Token);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            if (_currentState!=null) 
                Debug.Log($"Exit from state: {_currentState}");
            
            _currentState?.Exit(_cts.Token);
            var nextState = GetState<TState>();
            _currentState = nextState;
            return nextState;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _statesProvider.GetState<TState>();

        public async ValueTask DisposeAsync()
        {
            await _currentState?.Exit(_cts.Token)!;
            if (_cts?.IsCancellationRequested == false) 
                _cts.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }
}