﻿using WordSearch.AssetManagement;
using WordSearch.Data;
using WordSearch.UI.Grid;
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
            BindLevelsLoader();
            BindLevelsProvider();
            BindCurrentLevelProvider();
            BindAssetProvider();
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
            BindState<LoadLevelsState>();
            BindState<LoadLastLevelState>();
            BindState<LoadNextLevelState>();
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

        private void BindLevelsLoader()
        {
            Container
                .BindInterfacesTo<LevelsLoaderFromResources>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCurrentLevelProvider()
        {
            Container
                .BindInterfacesAndSelfTo<CurrentLevelProvider>()
                .AsSingle()
                .NonLazy();
        }
        
        private void BindLevelsProvider()
        {
            Container
                .BindInterfacesAndSelfTo<LevelsProvider>()
                .AsSingle()
                .NonLazy();
        }

        private void BindAssetProvider()
        {
            Container
                .BindInterfacesTo<AssetProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}