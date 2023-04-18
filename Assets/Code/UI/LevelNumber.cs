using TMPro;
using UnityEngine;
using WordSearch.Data.Interfaces;
using Zenject;

namespace WordSearch
{
    public class LevelNumber : MonoBehaviour
    {
        [SerializeField] private string _format = "Level {0}";
        [SerializeField] private TMP_Text _levelNumberText;
        
        private ICurrentLevelProvider _currentLevelProvider;

        [Inject]
        private void Construct(ICurrentLevelProvider currentLevelProvider) => 
            _currentLevelProvider = currentLevelProvider;

        private void Awake() => 
            SetText();

        private void SetText()
        {
            var levelNumber = _currentLevelProvider.LevelIndex + 1;
            var text = string.Format(_format, levelNumber);
            _levelNumberText.text = text;
        }
    }
}