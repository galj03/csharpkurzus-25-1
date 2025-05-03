using BSRKB5.Windows.Leaderboard;

namespace BSRKB5.Commands;
[Command("Show leaderboard", Text = "See leaderboard")]
internal class ShowLeaderboardCommand : IMenuCommand
{
    private readonly ILeaderboardWindowController _leaderboardWindowController;

    public ShowLeaderboardCommand(ILeaderboardWindowController leaderboardWindowController)
    {
        _leaderboardWindowController = leaderboardWindowController
            ?? throw new ArgumentNullException(nameof(leaderboardWindowController));
    }

    public string Text => "See leaderboard"; // TODO: constant texts, DRY
    public uint Order => 5;

    public void Execute(string[] args)
    {
        _leaderboardWindowController.ShowWindow();
    }
}
