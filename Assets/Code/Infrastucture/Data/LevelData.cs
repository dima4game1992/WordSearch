using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WordSearch.Data
{
    public sealed record LevelData
    {
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
        [JsonProperty(PropertyName = "grid")]
        public List<List<string>> Grid { get; set; }
        [JsonProperty(PropertyName = "words")]
        public List<string> Words { get; set; }
        [JsonProperty(PropertyName = "incorrect_input_behavior")]
        public IncorrectInputBehaviour IncorrectInputBehaviour { get; set; }

        public string[][] ConvertedGrid()
        {
            return Grid
                .Select(row => row.ToArray())
                .ToArray();
        }
    }
}