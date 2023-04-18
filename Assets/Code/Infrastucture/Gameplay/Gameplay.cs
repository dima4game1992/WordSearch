using System;
using System.Collections.Generic;
using WordSearch.Data;
using WordSearch.Data.Interfaces;
using WordSearch.UI.Grid;
using WordSearch.UI.Grid.Interfaces;
using Zenject;

namespace WordSearch
{
    public sealed class Gameplay : IInitializable, IDisposable
    {
        private readonly IGridGenerator _gridGenerator;
        private readonly IGridViewGenerator _gridViewGenerator;
        private readonly ICurrentLevelProvider _currentLevelProvider;
        private readonly GridPlaceholder _gridPlaceholder;
        private readonly GridPresenter.Factory _gridPresenterFactory;
        private GridPresenter _gridPresenter;

        public Gameplay(IGridGenerator gridGenerator,
            IGridViewGenerator gridViewGenerator,
            ICurrentLevelProvider currentLevelProvider,
            GridPlaceholder gridPlaceholder,
            GridPresenter.Factory gridPresenterFactory)
        {
            _gridGenerator = gridGenerator;
            _gridViewGenerator = gridViewGenerator;
            _currentLevelProvider = currentLevelProvider;
            _gridPlaceholder = gridPlaceholder;
            _gridPresenterFactory = gridPresenterFactory;
        }

        public void Initialize()
        {
            LevelData levelData = _currentLevelProvider.Value;
            var gridData = levelData.ConvertedGrid();
            IEnumerable<string> wordsToSearch = levelData.Words;

            IGrid grid = GenerateGrid(gridData, wordsToSearch);
            GridView gridView = GenerateGridView(gridData);
            _gridPresenter = CreateGridPresenter(grid, gridView);
            _gridPresenter.Initialize();
        }

        private IGrid GenerateGrid(string[][] gridData, IEnumerable<string> wordsToSearch)
        {
            return _gridGenerator.Generate(gridData, wordsToSearch);
        }

        private GridView GenerateGridView(string[][] gridData)
        {
            GridView gridView = _gridViewGenerator.Generate(gridData);
            gridView.transform.SetParent(_gridPlaceholder.transform, false);
            return gridView;
        }

        private GridPresenter CreateGridPresenter(IGrid grid, GridView gridView)
        {
            return _gridPresenterFactory.Create(grid, gridView);
        }

        public void Dispose()
        {
            _gridPresenter?.Dispose();
        }
    }
}