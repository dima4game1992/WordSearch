using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    public interface ISceneLoader
    {
        Task LoadSceneAsync(Scene nextScene, CancellationToken token);
    }
}