namespace BSRKB5.Commands;
[Command("Exit", Text = "Exit")]
internal class ExitCommand : IMenuCommand
{
    public string Text => "Exit";
    public uint Order => 99;

    public void Execute(string[] args)
    {
        Environment.Exit(0);
    }
}
