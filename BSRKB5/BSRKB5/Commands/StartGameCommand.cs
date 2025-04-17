namespace BSRKB5.Commands;
[Command("Start Game", Text = "Play")]
internal class StartGameCommand : ICommand
{
    public CommandType CommandType => CommandType.MainMenuCommand;

    public void Execute(string[] args)
    {
        //TODO: start the game
        throw new NotImplementedException();
    }
}
