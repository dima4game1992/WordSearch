using WordSearch.Data;

namespace WordSearch
{
    public interface IGridGenerator
    {
        GridView Generate(Level level);
    }
}