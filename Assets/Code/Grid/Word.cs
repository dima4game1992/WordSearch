namespace WordSearch
{
    public class Word : IWord
    {
        public Word(string value)
        {
            Value = value;
        }

        public string Value { get; }
        public bool IsOpened { get; set; }
    }
}