namespace BSRKB5.Models;
internal class GameField
{
    public bool IsBomb { get; init; }
    public string State { get; set; }

    public GameField(bool isBomb, string state)
    {
        IsBomb = isBomb;
        State = state;
    }
}