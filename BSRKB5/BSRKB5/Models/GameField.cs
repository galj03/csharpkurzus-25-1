namespace BSRKB5.Models;
internal class GameField
{
    public bool IsBomb { get; init; }
    public string State { get; set; }

    public int Row { get; init; }
    public int Column { get; init; }

    public GameField(bool isBomb, string state, int row, int column)
    {
        IsBomb = isBomb;
        State = state;
        Row = row;
        Column = column;
    }
}