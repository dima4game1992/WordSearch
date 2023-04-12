using Zenject;

namespace WordSearch
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGame();
            BindGameBootstrapper();
            BindGameStateMachine();
            BindGameStates();
            BindGameStatesProvider();
            BindSceneLoader();
        }

        private void BindGame()
        {
            Container
                .BindInterfacesAndSelfTo<Game>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameBootstrapper()
        {
            Container
                .BindInterfacesAndSelfTo<GameBootstrapper>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStateMachine()
        {
            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStates()
        {
            BindState<BootstrapState>();
            BindState<LoadLevelState>();
            BindState<GameLoopState>();

            void BindState<TState>() where TState : class, IExitableState
            {
                Container
                    .BindInterfacesAndSelfTo<TState>()
                    .AsSingle()
                    .NonLazy();
            }
        }

        private void BindGameStatesProvider()
        {
            Container
                .BindInterfacesAndSelfTo<GameStatesProvider>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSceneLoader()
        {
            Container
                .BindInterfacesTo<SceneLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}