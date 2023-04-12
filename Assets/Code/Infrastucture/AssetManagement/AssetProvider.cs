using UnityEngine;

namespace WordSearch.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
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