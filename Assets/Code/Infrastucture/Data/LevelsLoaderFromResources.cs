using System.Threading.Tasks;
using Newtonsoft.Json;
using WordSearch.AssetManagement;

namespace WordSearch.Data
{
    public class LevelsLoaderFromResources : ILevelsLoader
    {
        private readonly IAssetProvider _assetProvider;
        
        public LevelsLoaderFromResources(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Task<LevelsData> LoadLevels()
        {
            var levelsJson = _assetProvider.LoadLevelsJson(AssetPath.LevelsPath);
            var levelsData = JsonConvert.DeserializeObject<LevelsData>(levelsJson);
            return Task.FromResult(levelsData);
        }
    }
}