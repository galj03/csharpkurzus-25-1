using BSRKB5.Models;

using static BSRKB5.Constants;

namespace BSRKB5.Factories;

internal class GameStateFactory : IGameStateFactory
{
    private readonly Random _random = new();

    public GameState Create(int height, int width, int bombs)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height, nameof(height));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width, nameof(width));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bombs, height * width);

        var grid = GenerateGrid(height, width, bombs);
        return new GameState(grid);
    }

    private IList<IList<GameField>> GenerateGrid(int height, int width, int bombs)
    {
        var boolGrid = GenerateBombLocations(height, width, bombs);

        IList<IList<GameField>> grid = [];
        for (uint i = 0; i < height; i++)
        {
            var gameFieldRow = new List<GameField>();
            for (uint j = 0; j < width; j++)
            {
                var gameField = new GameField(boolGrid[i, j], GameFieldStates.NOT_DISCOVERED, i, j);
                gameFieldRow.Add(gameField);
            }

            grid.Add(gameFieldRow);
        }

        return grid;
    }

    private bool[,] GenerateBombLocations(int height, int width, int bombs)
    {
        var boolGrid = new bool[height, width];
        while (bombs > 0)
        {
            int row, column;

            do
            {
                row = _random.Next(height);
                column = _random.Next(width);
            } while (boolGrid[row, column]);

            boolGrid[row, column] = true;
            bombs--;
        }

        return boolGrid;
    }
}
