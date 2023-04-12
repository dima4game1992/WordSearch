using System.Collections.Generic;
using UnityEngine;

namespace WordSearch
{
    public class RowView : MonoBehaviour
    {
        public void SetLetters(IEnumerable<LetterView> letters)
        {
            foreach (LetterView letter in letters) 
                letter.transform.parent = transform;
        }
    }
}