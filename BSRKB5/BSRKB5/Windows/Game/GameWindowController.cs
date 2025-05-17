using BSRKB5.Communication;
using BSRKB5.Enums;
using BSRKB5.Windows.GameLost;
using BSRKB5.Windows.GameWon;

namespace BSRKB5.Windows.Game;
internal class GameWindowController : WindowController, IGameWindowController
{
    private readonly IGameWindow _gameWindow;
    private readonly IGameWonWindowController _gameWonWindowController;
    private readonly IGameLostWindowController _gameLostWindowController;

    public GameWindowController(
        IConsoleInput consoleInput,
        IGameWindow gameWindow,
        IGameWonWindowController gameWonWindowController,
        IGameLostWindowController gameLostWindowController)
        : base(consoleInput)
    {
        _gameWindow = gameWindow ?? throw new ArgumentNullException(nameof(gameWindow));
        _gameWonWindowController = gameWonWindowController ?? throw new ArgumentNullException(nameof(gameWonWindowController));
        _gameLostWindowController = gameLostWindowController ?? throw new ArgumentNullException(nameof(gameLostWindowController));
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
                _gameWonWindowController.SetGameTime(_gameWindow.GameService.GetGameTime());
                _gameWonWindowController.ShowWindow();
            }
            else
            {
                _gameLostWindowController.ShowWindow();
            }

            isExit = true;
        }
    }

    protected override void PrintContent()
    {
        _gameWindow.PrintContent();
    }
}
