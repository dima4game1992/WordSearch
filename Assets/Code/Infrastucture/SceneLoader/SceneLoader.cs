using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WordSearch
{
    public class SceneLoader : ISceneLoader
    {
        public async Task LoadSceneAsync(Scene nextScene, CancellationToken token)
        {
            var nextSceneName = nextScene.ToString();
            var activeScene = SceneManager.GetActiveScene();
            var activeSceneName = activeScene.name;
            
            if (activeSceneName != nextSceneName)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);

                while (operation.isDone == false && token.IsCancellationRequested == false) 
                    await Task.Yield();
            }
        }
    }
}