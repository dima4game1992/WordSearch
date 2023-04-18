using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WordSearch
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public IEnumerator StartCoroutinesParallel(IEnumerable<IEnumerator> coroutines)
        {
            return coroutines
                .Select(StartCoroutine)
                .ToList()
                .GetEnumerator();
        }
        
        public Coroutine StartCoroutines(IEnumerable<IEnumerator> coroutines)
        {
            return StartCoroutine(StartManyCoroutines(coroutines));
        }
        
        private IEnumerator StartManyCoroutines(IEnumerable<IEnumerator> coroutines)
        {
            foreach (IEnumerator coroutine in coroutines)
                yield return StartCoroutine(coroutine);
        }
    }
}