using UnityEngine;
using WordSearch.UI.Grid;
using Zenject;

namespace WordSearch
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        [SerializeField] private LetterAnimationSettings _letterAnimationSettings;
        [SerializeField] private ShakingAnimationSettings _shakingAnimationSettings;

        public override void InstallBindings()
        {
            BindLetterAnimationSettings();
            BindShakingAnimationSettings();
        }

        private void BindLetterAnimationSettings()
        {
            Container
                .Bind<LetterAnimationSettings>()
                .FromInstance(_letterAnimationSettings);
        }

        private void BindShakingAnimationSettings()
        {
            Container
                .Bind<ShakingAnimationSettings>()
                .FromInstance(_shakingAnimationSettings);
        }
    }
}