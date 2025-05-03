namespace BSRKB5.Commands;
internal interface IGameCommand : ICommand
{
    ConsoleKey ActivatorKey { get; }
}
