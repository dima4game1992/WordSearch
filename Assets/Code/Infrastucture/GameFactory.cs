using System.Collections.Generic;
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

        public GridView CreateGridView(IEnumerable<RowView> rowViews)
        {
            return _assetsProvider.Instantiate(AssetPath.GridViewPath)
                .GetComponent<GridView>();
        }

        public LetterView CreateLetterView(string letter)
        {
            return _assetsProvider.Instantiate(AssetPath.LetterViewPath)
                .GetComponent<LetterView>();
        }

        public RowView CreateRowView(IEnumerable<LetterView> letters)
        {
            return _assetsProvider.Instantiate(AssetPath.RowViewPath)
                .GetComponent<RowView>();
        }
    }
}