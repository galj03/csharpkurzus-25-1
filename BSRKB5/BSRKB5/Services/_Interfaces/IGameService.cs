using BSRKB5.Enums;

namespace BSRKB5.Services;
internal interface IGameService
{
    void StartGame();
    bool IsGameFinished();
    bool IsGameWon();
    TimeSpan GetGameTime();

    string GetGameStateAsString();

    void ChangeRowIndexBy(int rowIndexDifference);
    void ChangeColumnIndexBy(int columnIndexDifference);
    void ChangeCurrentGameField(GameFieldChange gameFieldChange);
}