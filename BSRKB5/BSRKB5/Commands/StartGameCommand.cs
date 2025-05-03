namespace BSRKB5.Commands;
[Command("Start Game", Text = "Play")]
internal class StartGameCommand : IMenuCommand
{
    public CommandType CommandType => CommandType.MainMenuCommand;

    public string Text => "Play";

    public void Execute(string[] args)
    {
        //TODO: start the game
        // 9x9 grid, with 20 mines
        throw new NotImplementedException();
    }
}
