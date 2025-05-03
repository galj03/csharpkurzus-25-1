namespace BSRKB5.Commands;
[Command("Start Game", Text = "Play")]
internal class StartGameCommand : IMenuCommand
{
    public string Text => "Play";

    public uint Order => 0;

    public void Execute(string[] args)
    {
        //TODO: start the game
        // 9x9 grid, with 20 mines
        // saving result at the end could be an async Task
        throw new NotImplementedException();
    }
}
