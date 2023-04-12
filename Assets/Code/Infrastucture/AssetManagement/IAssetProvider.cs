using UnityEngine;

namespace WordSearch.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
    }
}