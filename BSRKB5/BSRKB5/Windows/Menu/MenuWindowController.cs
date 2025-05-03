using BSRKB5.Commands;
using BSRKB5.Communication;

namespace BSRKB5.Windows.Menu;
internal class MenuWindowController : WindowController, IMenuWindowController
{
    private readonly IMenuWindow _menuWindow;
    private readonly IList<IMenuCommand> _menuCommands;

    public MenuWindowController(IConsoleInput consoleInput, IMenuWindow menuWindow, IEnumerable<IMenuCommand> menuCommands)
        : base(consoleInput)
    {
        _menuWindow = menuWindow ?? throw new ArgumentNullException(nameof(menuWindow));
        _menuCommands = menuCommands?.ToList() ?? throw new ArgumentNullException(nameof(menuCommands));
    }

    protected override void HandleInput(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                //CurrentWindow.SelectedIndex++; //TODO: test if this would work as well
                _menuWindow.SelectedIndex += 1;
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                _menuWindow.SelectedIndex -= 1;
                break;
            case ConsoleKey.Enter:
                var command = _menuCommands[_menuWindow.SelectedIndex];
                command.Execute();
                break;
        }
    }

    protected override void PrintContent()
    {
        _menuWindow.PrintContent();
    }
}
