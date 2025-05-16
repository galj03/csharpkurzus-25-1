using BSRKB5.Communication;
using BSRKB5.Enums;

namespace BSRKB5.Windows.Game;
internal class GameWindowController : WindowController, IGameWindowController
{
    private readonly IGameWindow _gameWindow;

    public GameWindowController(
        IConsoleInput consoleInput,
        IGameWindow gameWindow)
        : base(consoleInput)
    {
        _gameWindow = gameWindow ?? throw new ArgumentNullException(nameof(gameWindow));
    }

    public override void ShowWindow()
    {
        _gameWindow.GameService.StartGame();
        base.ShowWindow();
    }

    protected override void HandleInput(ConsoleKeyInfo keyInfo, out bool isExit)
    {
        isExit = false;

        switch (keyInfo.Key)
        {
            //MOVEMENT
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                _gameWindow.GameService.ChangeRowIndexBy(-1);
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                _gameWindow.GameService.ChangeRowIndexBy(1);
                break;
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                _gameWindow.GameService.ChangeColumnIndexBy(-1);
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                _gameWindow.GameService.ChangeColumnIndexBy(1);
                break;

            //ACTIONS
            case ConsoleKey.F:
                _gameWindow.GameService.ChangeCurrentGameField(GameFieldChange.Flag);
                break;
            case ConsoleKey.G:
                _gameWindow.GameService.ChangeCurrentGameField(GameFieldChange.Question);
                break;
            case ConsoleKey.H:
                _gameWindow.GameService.ChangeCurrentGameField(GameFieldChange.Safe);
                break;

            //EXIT
            case ConsoleKey.Q:
            case ConsoleKey.Escape:
                isExit = true;
                break;
        }

        if (_gameWindow.GameService.IsGameFinished())
        {
            if (_gameWindow.GameService.IsGameWon())
            {
                //TODO: retrieve name and save result
            }
            else
            {
                //TODO: if lost, then show a message -> exit with q
            }

            isExit = true;
        }
    }

    protected override void PrintContent()
    {
        _gameWindow.PrintContent();
    }
}
