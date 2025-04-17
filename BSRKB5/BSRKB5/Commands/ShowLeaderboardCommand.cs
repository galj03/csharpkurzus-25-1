namespace BSRKB5.Commands;
[Command("Show leaderboard", Text = "See leaderboard")]
internal class ShowLeaderboardCommand : ICommand
{
    public CommandType CommandType => CommandType.MainMenuCommand;

    public void Execute(string[] args)
    {
        //TODO: show leaderboard window
        throw new NotImplementedException();
    }
}
