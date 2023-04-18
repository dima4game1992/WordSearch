using UnityEngine;

namespace WordSearch.AssetManagement
{
    public interface IAssetProvider
    {
        T GetPrefab<T>(string path) where T : Object;
        GameObject Instantiate(string path);
        string LoadLevelsJson(string path);
    }
}