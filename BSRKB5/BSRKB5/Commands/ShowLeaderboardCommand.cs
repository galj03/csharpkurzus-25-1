namespace BSRKB5.Commands;
[Command("Show leaderboard", Text = "See leaderboard")]
internal class ShowLeaderboardCommand : IMenuCommand
{
    public CommandType CommandType => CommandType.MainMenuCommand;

    public string Text => "See leaderboard"; // TODO: constant texts, DRY

    public void Execute(string[] args)
    {
        //TODO: show leaderboard window
        throw new NotImplementedException();
    }
}
