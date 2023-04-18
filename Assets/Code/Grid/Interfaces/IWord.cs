namespace WordSearch
{
    public interface IWord
    {
        string Value { get; }
        bool IsOpened { get; set; }
    }
}