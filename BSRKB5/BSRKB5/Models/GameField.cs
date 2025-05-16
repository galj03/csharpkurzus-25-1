namespace BSRKB5.Models;
internal class GameField
{
    public bool IsBomb { get; init; }
    public string State { get; set; }

    public uint Row { get; init; }
    public uint Column { get; init; }

    public GameField(bool isBomb, string state, uint row, uint column)
    {
        IsBomb = isBomb;
        State = state;
        Row = row;
        Column = column;
    }
}