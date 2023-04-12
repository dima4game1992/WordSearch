using TMPro;
using UnityEngine;

namespace WordSearch
{
    public class LetterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;

        public void SetChar(char @char)
        {
            _tmpText.text = @char
                .ToString()
                .ToUpper();
        }
    }
}