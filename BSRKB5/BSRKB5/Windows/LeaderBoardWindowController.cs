using BSRKB5.Communication;

namespace BSRKB5.Windows;
internal class LeaderBoardWindowController : WindowController, IWindowController
{
    public LeaderBoardWindowController(IConsoleInput consoleInput)//TODO: window
        : base(consoleInput)
    { }

    protected override void HandleInput(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Q)
        {
            //TODO: back to menu with no memory leaks
            // use singletons for windows!!!!
        }
    }

    protected override void PrintContent()
    {
        throw new NotImplementedException();
    }
}
