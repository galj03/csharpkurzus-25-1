//TODO: apply SOLID, this is just a sketch for the main menu
var selectedIndex = 0;
var menuOptions = new List<string> { "Play", "See leaderboard", "Exit" };   //TODO: get from a resource
while (true)
{
    PrintMenu(menuOptions, selectedIndex);

    var keyInfo = Console.ReadKey();
    var indexModifier = 0;
    switch (keyInfo.Key)
    {
        case ConsoleKey.UpArrow:
        case ConsoleKey.W:
            indexModifier = -1;
            break;
        case ConsoleKey.DownArrow:
        case ConsoleKey.S:
            indexModifier = 1;
            break;
        case ConsoleKey.Enter:
            //TODO: handle functionalities
            break;
    }

    selectedIndex = (selectedIndex + indexModifier) % menuOptions.Count; //TODO: fix negative cases
}

static void PrintMenu(IList<string> menuOptions, int selectedIndex)
{
    Console.Clear();
    Console.WriteLine("Minesweeper App in C#");
    Console.WriteLine("----------------------\n");

    for (int i = 0; i < menuOptions.Count; i++)
    {
        var text = i == selectedIndex ? $"{menuOptions[i]} <-" : menuOptions[i]; //TODO: make a method handle this
        Console.WriteLine(text);
    }
    Console.WriteLine();
}