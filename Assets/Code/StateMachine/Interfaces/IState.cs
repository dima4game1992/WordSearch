using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public interface IState : IExitableState
    {
        Task Enter(CancellationToken cancellationToken);
    }

    public interface IPayloadedState<in TPayload> : IExitableState
    {
        Task Enter(TPayload payload, CancellationToken token);
    }

    public interface IExitableState
    {
        Task Exit(CancellationToken token);
    }
}