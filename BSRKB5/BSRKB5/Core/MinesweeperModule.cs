using System.Reflection;

using BSRKB5.Commands;
using BSRKB5.Communication;
using BSRKB5.Windows.Menu;

using Microsoft.Extensions.DependencyInjection;

namespace BSRKB5.Core;
public class MinesweeperModule
{
    public static void LoadModule(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IConsoleInput, ConsoleInput>();
        serviceCollection.AddSingleton<IConsoleOutput, ConsoleOutput>();

        RegisterWindows(serviceCollection);

        RegisterCommands(serviceCollection);
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

        //TODO: other windows
    }

    //TODO: fix command orders for menu
    private static void RegisterCommands(IServiceCollection serviceCollection)
    {
        var commands = DiscoverCommands();

        var menuCommands = commands.Where(c => c is IMenuCommand);
        foreach (var menuCommand in menuCommands)
        {
            serviceCollection.AddSingleton(typeof(IMenuCommand), menuCommand.GetType());
        }

        var gameCommands = commands.Where(c => c is IGameCommand);
        foreach (var gameCommand in gameCommands)
        {
            serviceCollection.AddSingleton(typeof(IGameCommand), gameCommand.GetType());
        }
    }

    private static IEnumerable<ICommand> DiscoverCommands()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(IsCommandType)
            .Select(Activator.CreateInstance)
            .OfType<ICommand>()
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
