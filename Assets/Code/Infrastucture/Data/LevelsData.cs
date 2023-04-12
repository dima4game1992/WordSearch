using System.Collections.Generic;

namespace WordSearch.Data
{
    public sealed record LevelsData
    {
        public List<Level> levels { get; set; }
    }
    
    public sealed record Level
    {
        public int level { get; set; }
        public List<List<string>> grid { get; set; }
        public List<Word> words { get; set; }
        public string incorrect_input_behavior { get; set; }
    }
    
    public sealed record Word
    {
        public string word { get; set; }
    }
}