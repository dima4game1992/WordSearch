using UniRx;

namespace WordSearch
{
    public interface ILetter
    {
        string Value { get; }
        LetterPosition Position { get; }
        bool IsEmpty { get; }
        IReadOnlyReactiveProperty<bool> IsOpened { get; }
        void Open();
    }
}