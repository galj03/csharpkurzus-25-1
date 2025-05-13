using System.Reflection;

using BSRKB5.Commands;
using BSRKB5.Communication;
using BSRKB5.Services;
using BSRKB5.Windows.Leaderboard;
using BSRKB5.Windows.Menu;

using Microsoft.Extensions.DependencyInjection;

namespace BSRKB5.Core;
public class MinesweeperModule
{
    public static void LoadModule(IServiceCollection serviceCollection, string jsonFileLocation)
    {
        serviceCollection.AddSingleton<IConsoleInput, ConsoleInput>();
        serviceCollection.AddSingleton<IConsoleOutput, ConsoleOutput>();

        RegisterWindows(serviceCollection);

        RegisterCommands(serviceCollection);

        RegisterServices(serviceCollection, jsonFileLocation);
    }

    private static void RegisterServices(IServiceCollection serviceCollection, string jsonFileLocation)
    {
        serviceCollection.AddSingleton<IGameResultService>(modules =>
        {
            return new GameResultService(jsonFileLocation);
        });
    }

    private static void RegisterWindows(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMenuWindowController, MenuWindowController>();
        serviceCollection.AddSingleton<IMenuWindow>(modules =>
        {
            var menuCommands = modules.GetServices<IMenuCommand>();
            var menuTexts = menuCommands.Select(c => c.Text).ToList();
            var consoleOutput = modules.GetRequiredService<IConsoleOutput>();
            return new MenuWindow(menuTexts, consoleOutput);
        });

        serviceCollection.AddSingleton<ILeaderboardWindowController, LeaderboardWindowController>();
        serviceCollection.AddSingleton<ILeaderboardWindow, LeaderboardWindow>();

        //TODO: other windows
    }

    private static void RegisterCommands(IServiceCollection serviceCollection)
    {
        var commandTypes = GetCommandTypes();

        var menuCommandTypes = commandTypes.Where(t => t.IsAssignableTo(typeof(IMenuCommand)));
        foreach (var menuCommandType in menuCommandTypes.Reverse()) // the reverse is required for the correct order when injecting
        {
            serviceCollection.AddSingleton(typeof(IMenuCommand), menuCommandType);
        }

        var gameCommandTypes = commandTypes.Where(t => t.IsAssignableTo(typeof(IGameCommand)));
        foreach (var gameCommandType in gameCommandTypes)
        {
            serviceCollection.AddSingleton(typeof(IGameCommand), gameCommandType);
        }
    }

    private static IEnumerable<Type> GetCommandTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(IsCommandType)
            .ToList();
    }

    private static bool IsCommandType(Type type)
    {
        return type.IsDefined(typeof(CommandAttribute)) && type is
        {
            IsInterface: false,
            IsAbstract: false,
            IsGenericType: false,
            IsNested: false
        };
    }
}
