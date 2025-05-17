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
    private DateTime _endTime;
    private int _safeSquares;

    public GameService(IGameStateFactory gameStateFactory)
    {
        _gameStateFactory = gameStateFactory ?? throw new ArgumentNullException(nameof(gameStateFactory));
    }

    public void StartGame()
    {
        _gameStateInstance = _gameStateFactory.Create(
            GameDefaults.MAP_HEIGHT,
            GameDefaults.MAP_WIDTH,
            GameDefaults.BOMBS_COUNT);
        _startTime = DateTime.Now;
        _safeSquares = 0;
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
                    FinishGame(false);
                }
                else
                {
                    RevealField(currentGameField);

                    int fieldCount = _gameStateInstance.Width * _gameStateInstance.Height;
                    int fieldsRemaining = fieldCount - _safeSquares;
                    if (fieldsRemaining == _gameStateInstance.BombCount)
                    {
                        FinishGame(true);
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameFieldChange));
        }
    }

    private void RevealField(GameField currentGameField)
    {
        if (currentGameField.State[0] >= '0' && currentGameField.State[0] < '9')
        {
            return;
        }

        _safeSquares++;

        IEnumerable<GameField> neighbors = GetNeighboringFields(currentGameField);

        var bombsCount = 0;
        foreach (GameField neighbor in neighbors)
        {
            if (neighbor.IsBomb)
            {
                bombsCount++;
            }
        }

        currentGameField.State = bombsCount.ToString();
        if (bombsCount == 0)
        {
            foreach (GameField neighbor in neighbors)
            {
                RevealField(neighbor);
            }
        }
    }

    private IEnumerable<GameField> GetNeighboringFields(GameField currentGameField)
    {
        var neighbors = new List<GameField>();

        var rowMinimum = Math.Max(0, currentGameField.Row - 1);
        var rowMaximum = Math.Min(_gameStateInstance.Height - 1, currentGameField.Row + 1);
        var columnMinimum = Math.Max(0, currentGameField.Column - 1);
        var columnMaximum = Math.Min(_gameStateInstance.Width - 1, currentGameField.Column + 1);
        for (int i = rowMinimum; i <= rowMaximum; i++)
        {
            for (int j = columnMinimum; j <= columnMaximum; j++)
            {
                if (!(i == currentGameField.Row && j == currentGameField.Column))
                {
                    neighbors.Add(_gameStateInstance.Grid[i][j]);
                }
            }
        }

        return neighbors;
    }

    public GameField GetCurrentGameField()
    {
        return _gameStateInstance.Grid[_gameStateInstance.RowIndex][_gameStateInstance.ColumnIndex];
    }

    public string GetGameStateAsString()
    {
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

    public bool IsGameWon()
    {
        return _gameStateInstance.IsWon;
    }

    public TimeSpan GetGameTime()
    {
        return IsGameFinished() ? (_endTime - _startTime) : TimeSpan.Zero;
    }

    private void FinishGame(bool isWon)
    {
        _gameStateInstance.IsFinished = true;
        _endTime = DateTime.Now;
        _gameStateInstance.IsWon = isWon;
    }
}