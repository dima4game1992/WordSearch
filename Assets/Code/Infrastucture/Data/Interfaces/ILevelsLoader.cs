using System.Threading.Tasks;

namespace WordSearch.Data.Interfaces
{
    public interface ILevelsLoader
    {
        Task<LevelsData> LoadLevels();
    }
}