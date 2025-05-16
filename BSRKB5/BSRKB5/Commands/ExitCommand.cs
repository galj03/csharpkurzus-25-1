using static BSRKB5.Constants;

namespace BSRKB5.Commands;
[Command("Exit", Text = MenuCommands.EXIT_TEXT)]
internal class ExitCommand : IMenuCommand
{
    public string Text => MenuCommands.EXIT_TEXT;
    public uint Order => 66;

    public void Execute(string[] args)
    {
        Environment.Exit(0);
    }
}
