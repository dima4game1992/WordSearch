using UnityEngine;

namespace WordSearch.AssetManagement
{
    public sealed class AssetProvider : IAssetProvider
    {
        public T GetPrefab<T>(string path) where T : Object
            => Resources.Load<T>(path);

        public GameObject Instantiate(string path)
        {
            var prefab = GetPrefab<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public string LoadLevelsJson(string path)
        {
            return Resources
                .Load<TextAsset>(path)
                .text;
        }
    }
}