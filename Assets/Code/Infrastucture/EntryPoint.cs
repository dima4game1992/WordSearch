using UnityEngine;
using Zenject;

namespace WordSearch
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private RunnableContext _contextPrefab;

        private void Awake()
        {
            var context = FindObjectOfType<RunnableContext>();
            
            if (context == null)
                context = Instantiate(_contextPrefab);

            if (context.Initialized == false)
                context.Run();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}