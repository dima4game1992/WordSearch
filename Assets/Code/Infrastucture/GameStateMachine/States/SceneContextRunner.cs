using UnityEngine;
using Zenject;

namespace WordSearch
{
    [RequireComponent(typeof(SceneContext))]
    public class SceneContextRunner : MonoBehaviour
    {
        [SerializeField] private RunnableContext _context;

        private RunnableContext Context => _context != null
            ? _context
            : _context = GetComponent<RunnableContext>();

        public void Run()
        {
            if (Context.Initialized == false)
                Context.Run();
        }
    }
}