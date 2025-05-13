using BSRKB5.Core;
using BSRKB5.Windows.Menu;

using Microsoft.Extensions.DependencyInjection;

try
{
    var jsonFileLocation = Path.Combine(AppContext.BaseDirectory, "_Data", "leaderboard.json");

    var serviceCollection = new ServiceCollection();
    MinesweeperModule.LoadModule(serviceCollection, jsonFileLocation);
    var serviceProvider = serviceCollection.BuildServiceProvider(true);

    var menuController = serviceProvider.GetRequiredService<IMenuWindowController>();
    menuController.ShowWindow();
}
catch (Exception e)
{
    Console.Clear();
    Console.WriteLine($"Unexpected error: {e.Message}");
}