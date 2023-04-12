using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public sealed class GameLoopState : IState
    {
        public Task Enter(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Exit(CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}