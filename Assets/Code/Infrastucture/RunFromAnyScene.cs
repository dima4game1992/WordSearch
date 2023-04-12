using UnityEngine;
using UnityEngine.SceneManagement;

namespace WordSearch
{
    public class RunFromAnyScene : MonoBehaviour
    {
        private void Awake()
        {
            var entryPoint = FindObjectOfType<EntryPoint>();
            if (entryPoint != null)
            {
                Destroy(gameObject);
                return;
            }

            SceneManager.LoadScene(Scene.Bootstrap.ToString());
        }
    }
}