using BSRKB5.Core;
using BSRKB5.Windows.Menu;

using Microsoft.Extensions.DependencyInjection;

var menuOptions = new List<string> { "Play", "See leaderboard", "Exit" };   //TODO: get commands using reflection in window

try
{
    var serviceCollection = new ServiceCollection();
    MinesweeperModule.LoadModule(serviceCollection);
    var serviceProvider = serviceCollection.BuildServiceProvider(true);

    var menuController = serviceProvider.GetRequiredService<IMenuWindowController>();
    menuController.ShowWindow();
}
catch (Exception e)
{
    Console.Clear();
    Console.WriteLine($"Unexpected error: {e.Message}");
}