using BSRKB5.Communication;

namespace BSRKB5.Windows.GameLost;
internal class GameLostWindowController : WindowController, IGameLostWindowController
{
    private readonly IGameLostWindow _gameLostWindow;

    public GameLostWindowController(
        IConsoleInput consoleInput,
        IGameLostWindow gameWindow)
        : base(consoleInput)
    {
        _gameLostWindow = gameWindow ?? throw new ArgumentNullException(nameof(gameWindow));
    }

    protected override void HandleInput(ConsoleKeyInfo keyInfo, out bool isExit)
    {
        isExit = false;

        switch (keyInfo.Key)
        {
            //EXIT
            case ConsoleKey.Q:
            case ConsoleKey.Escape:
                isExit = true;
                break;
        }
    }

    protected override void PrintContent()
    {
        _gameLostWindow.PrintContent();
    }
}
