using System.Threading.Tasks;

namespace WordSearch.Data
{
    public interface ILevelsLoader
    {
        Task<LevelsData> LoadLevels();
    }
}