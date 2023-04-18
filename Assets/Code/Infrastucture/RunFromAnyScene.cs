using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

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
            
            var context = FindObjectOfType<RunnableContext>();
            if (context == null)
                DestroyImmediate(context);

            SceneManager.LoadScene(Scene.Bootstrap.ToString());
        }
    }
}