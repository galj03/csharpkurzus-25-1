namespace BSRKB5.Commands;
[Command("Exit", Text = "Exit")]
internal class ExitCommand : IMenuCommand
{
    public CommandType CommandType => CommandType.MainMenuCommand;

    public string Text => "Exit";

    public void Execute(string[] args)
    {
        Environment.Exit(0);
    }
}
