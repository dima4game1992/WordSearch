using WordSearch.AssetManagement;

namespace WordSearch
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetsProvider;

        public GameFactory(IAssetProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public GridView CreateGridView()
        {
            return _assetsProvider.Instantiate(AssetPath.GridPath)
                .GetComponent<GridView>();
        }
    }
}