using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordSearch
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        IEnumerator StartCoroutinesParallel(IEnumerable<IEnumerator> coroutines);
        Coroutine StartCoroutines(IEnumerable<IEnumerator> coroutines);
    }
}