namespace BSRKB5.Models;
internal class GameState
{
    public IList<IList<GameField>> Grid { get; }
    public int RowIndex { get; set; }
    public int ColumnIndex { get; set; }
    public int Width { get; }
    public int Height { get; }

    public bool IsFinished { get; set; }
    public bool IsWon { get; set; }

    public GameState(IList<IList<GameField>> grid)
    {
        Grid = grid ?? throw new ArgumentNullException(nameof(grid));
        Height = grid.Count;
        Width = grid[0].Count;

        RowIndex = 0;
        ColumnIndex = 0;
        IsFinished = false;
        IsWon = false;
    }
}
