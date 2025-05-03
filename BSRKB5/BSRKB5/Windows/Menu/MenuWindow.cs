using BSRKB5.Communication;

namespace BSRKB5.Windows.Menu;
internal class MenuWindow : IMenuWindow
{
    public int SelectedIndex { get => _selectedIndex; set => SetSelectedIndex(value); }

    private int _selectedIndex;
    private readonly IList<string> _menuOptions;
    private readonly IConsoleOutput _consoleOutput;

    public MenuWindow(IList<string> menuOptions, IConsoleOutput consoleOutput)
    {
        _selectedIndex = 0;
        _menuOptions = menuOptions ?? throw new ArgumentNullException(nameof(menuOptions));
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("Minesweeper App in C#");
        _consoleOutput.WriteLine("----------------------\n");

        for (int i = 0; i < _menuOptions.Count; i++)
        {
            var menuOptionText = GetMenuOptionText(i);
            _consoleOutput.WriteLine(menuOptionText);
        }
        _consoleOutput.WriteLine();
    }

    private string GetMenuOptionText(int index)
    {
        return index == SelectedIndex ? $"{_menuOptions[index]} <-" : _menuOptions[index];
    }

    private void SetSelectedIndex(int value)
    {
        value = value % _menuOptions.Count;
        _selectedIndex = value < 0 ? _menuOptions.Count + value : value;
    }

    //TODO: move to controller???
    private void ChangeIndex(ConsoleKey key)
    {
        var indexModifier = 0;
        switch (key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                indexModifier = -1;
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                indexModifier = 1;
                break;
        }

        SelectedIndex = (SelectedIndex + indexModifier) % _menuOptions.Count;
        if (SelectedIndex < 0)
        {
            SelectedIndex = _menuOptions.Count - 1;
        }
    }
}
