namespace BSRKB5.Windows;
internal class MenuWindow : IWindow
{
    private readonly IList<string> _menuOptions;
    private int _selectedIndex;

    public MenuWindow(IList<string> menuOptions)
    {
        _menuOptions = menuOptions ?? throw new ArgumentNullException(nameof(menuOptions));
        _selectedIndex = 0;
    }

    public void ShowWindow()
    {
        while (true)
        {
            PrintContent();

            //TODO: key reading into a method
            var keyInfo = Console.ReadKey();

            //TODO: method
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                //TODO
            }

            ChangeIndex(keyInfo.Key);
        }
    }

    public void PrintContent()
    {
        Console.Clear();
        Console.WriteLine("Minesweeper App in C#");
        Console.WriteLine("----------------------\n");

        for (int i = 0; i < _menuOptions.Count; i++)
        {
            var menuOptionText = GetMenuOptionText(i);
            Console.WriteLine(menuOptionText);
        }
        Console.WriteLine();
    }

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

        _selectedIndex = (_selectedIndex + indexModifier) % _menuOptions.Count;
        if (_selectedIndex < 0)
        {
            _selectedIndex = _menuOptions.Count - 1;
        }
    }

    private string GetMenuOptionText(int index)
    {
        return index == _selectedIndex ? $"{_menuOptions[index]} <-" : _menuOptions[index];
    }
}
