using System;
using UniRx;

namespace WordSearch
{
    public sealed class Letter : ILetter
    {
        private readonly BoolReactiveProperty _isOpened;

        public Letter(string letter, LetterPosition position, bool isOpened = false)
        {
            if (letter.Length > 1)
                throw new ArgumentException(nameof(letter));

            Value = letter;
            Position = position;
            _isOpened = new BoolReactiveProperty(isOpened);
        }

        public string Value { get; }
        public LetterPosition Position { get; }
        public bool IsEmpty => string.IsNullOrEmpty(Value);
        public IReadOnlyReactiveProperty<bool> IsOpened => _isOpened;

        public void Open()
        {
            if (IsOpened.Value)
                return;

            _isOpened.Value = true;
        }

        public override string ToString() => Value;
    }
}