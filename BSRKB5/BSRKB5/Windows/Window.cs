using System.Reflection;

using BSRKB5.Commands;

namespace BSRKB5.Windows;
//TODO: consider using an abstract class if there are common parts between windows
internal abstract class Window : IWindow //TODO: fix reflection!!!
{
    protected readonly IEnumerable<ICommand> _commands = DiscoverCommands();

    private static IEnumerable<ICommand> DiscoverCommands()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(IsCommandType)
            .Select(Activator.CreateInstance)
            .OfType<ICommand>()
            .Where(c => c.CommandType == WindowCommandsType)
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

    public abstract void ShowWindow();
    public abstract void PrintContent();

    protected static CommandType WindowCommandsType { get; }
}
