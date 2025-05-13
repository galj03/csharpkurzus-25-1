using BSRKB5.Enums;
using BSRKB5.Factories;
using BSRKB5.Models;

using static BSRKB5.Constants;

namespace BSRKB5.Services;

internal class GameService : IGameService
{
    private GameState _gameStateInstance;
    private readonly IGameStateFactory _gameStateFactory;
    private DateTime _startTime;

    public GameService(IGameStateFactory gameStateFactory)
    {
        _gameStateFactory = gameStateFactory ?? throw new ArgumentNullException(nameof(gameStateFactory));
    }

    public void StartGame()
    {
        _gameStateInstance = _gameStateFactory.Create(9, 9, 20);
        _startTime = DateTime.Now;
    }

    public void ChangeCurrentGameField(GameFieldChange gameFieldChange)
    {
        var currentGameField = GetCurrentGameField();

        switch (gameFieldChange)
        {
            case GameFieldChange.Flag:
                currentGameField.State = GameFieldStates.FLAGGED;
                break;
            case GameFieldChange.Question:
                currentGameField.State = GameFieldStates.QUESTIONED;
                break;
            case GameFieldChange.Safe:
                if (currentGameField.IsBomb)
                {
                    //TODO: if bomb, then game is finished with a loss
                    _gameStateInstance.IsFinished = true;
                }
                else
                {
                    //TODO: show values, recursively

                    //maybe store how many safe squares have been located
                    //TODO: if win, then:
                    // 1. calculate TimeSpan
                    // 2. Get name
                    // 3. Save + Exit
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameFieldChange));
        }
    }

    public GameField GetCurrentGameField()
    {
        return _gameStateInstance.Grid[_gameStateInstance.RowIndex][_gameStateInstance.ColumnIndex];
    }

    public string GetGameStateAsString()
    {
        //TODO: highlight current somehow
        var result = "";
        for (int i = 0; i < _gameStateInstance.Height; i++)
        {
            for (int j = 0; j < _gameStateInstance.Width; j++)
            {
                result += _gameStateInstance.Grid[i][j].State;
            }

            if (i == _gameStateInstance.RowIndex)
            {
                result += " <";
            }

            result += Environment.NewLine;
        }
        for (int i = 0; i < _gameStateInstance.ColumnIndex; i++)
        {
            result += " ";
        }
        result += "^";

        return result;
    }

    public void ChangeColumnIndexBy(int columnIndexDifference)
    {
        var columnIndex = _gameStateInstance.ColumnIndex;
        columnIndex += columnIndexDifference;

        if (columnIndex < 0)
        {
            columnIndex = 0;
        }
        else if (columnIndex >= _gameStateInstance.Width)
        {
            columnIndex = _gameStateInstance.Width - 1;
        }

        _gameStateInstance.ColumnIndex = columnIndex;
    }

    public void ChangeRowIndexBy(int rowIndexDifference)
    {
        var rowIndex = _gameStateInstance.RowIndex;
        rowIndex += rowIndexDifference;

        if (rowIndex < 0)
        {
            rowIndex = 0;
        }
        else if (rowIndex >= _gameStateInstance.Height)
        {
            rowIndex = _gameStateInstance.Height - 1;
        }

        _gameStateInstance.RowIndex = rowIndex;
    }

    public bool IsGameFinished()
    {
        return _gameStateInstance.IsFinished;
    }
}