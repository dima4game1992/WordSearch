namespace WordSearch.Data.Interfaces
{
    public interface ICurrentLevelProvider
    {
        LevelData Value { get; }
        int LevelIndex { get; }
    }
}