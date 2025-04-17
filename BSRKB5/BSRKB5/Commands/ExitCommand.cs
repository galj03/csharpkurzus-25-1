namespace BSRKB5.Commands;
[Command("Exit", Text = "Exit")]
internal class ExitCommand : ICommand
{
    public CommandType CommandType => CommandType.MainMenuCommand;

    public void Execute(string[] args)
    {
        Environment.Exit(0);
    }
}
