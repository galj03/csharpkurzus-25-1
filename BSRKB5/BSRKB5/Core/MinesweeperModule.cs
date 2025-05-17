using System.Reflection;

using BSRKB5.Commands;
using BSRKB5.Communication;
using BSRKB5.Factories;
using BSRKB5.Services;
using BSRKB5.Windows.Game;
using BSRKB5.Windows.GameLost;
using BSRKB5.Windows.GameWon;
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

        RegisterFactories(serviceCollection);

        RegisterWindows(serviceCollection);

        RegisterCommands(serviceCollection);

        RegisterServices(serviceCollection, jsonFileLocation);
    }

    private static void RegisterFactories(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IGameStateFactory, GameStateFactory>();
        serviceCollection.AddSingleton<IGameResultFactory, GameResultFactory>();
    }

    private static void RegisterServices(IServiceCollection serviceCollection, string jsonFileLocation)
    {
        serviceCollection.AddSingleton<IGameResultService>(modules =>
        {
            return new GameResultService(jsonFileLocation);
        });
        serviceCollection.AddSingleton<IGameService, GameService>();
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

        serviceCollection.AddSingleton<IGameWindowController, GameWindowController>();
        serviceCollection.AddSingleton<IGameWindow, GameWindow>();

        serviceCollection.AddSingleton<IGameWonWindowController, GameWonWindowController>();
        serviceCollection.AddSingleton<IGameWonWindow, GameWonWindow>();

        serviceCollection.AddSingleton<IGameLostWindowController, GameLostWindowController>();
        serviceCollection.AddSingleton<IGameLostWindow, GameLostWindow>();
    }

    private static void RegisterCommands(IServiceCollection serviceCollection)
    {
        var commandTypes = GetCommandTypes();

        var menuCommandTypes = commandTypes.Where(t => t.IsAssignableTo(typeof(IMenuCommand)));
        foreach (var menuCommandType in menuCommandTypes.Reverse()) // the reverse is required for the correct order when injecting
        {
            serviceCollection.AddSingleton(typeof(IMenuCommand), menuCommandType);
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
