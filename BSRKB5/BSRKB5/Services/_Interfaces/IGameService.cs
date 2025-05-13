using BSRKB5.Enums;
using BSRKB5.Models;

namespace BSRKB5.Services;
internal interface IGameService
{
    void StartGame();
    bool IsGameFinished();

    string GetGameStateAsString();

    GameField GetCurrentGameField(); //TODO: make private?
    void ChangeRowIndexBy(int rowIndexDifference);
    void ChangeColumnIndexBy(int columnIndexDifference);
    void ChangeCurrentGameField(GameFieldChange gameFieldChange);
}