namespace WordSearch
{
    public interface IStatesProvider
    {
        TState GetState<TState>() where TState : class, IExitableState;
    }
}