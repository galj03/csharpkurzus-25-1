using BSRKB5.Windows.Leaderboard;

using static BSRKB5.Constants;

namespace BSRKB5.Commands;
[Command("Show leaderboard", Text = MenuCommands.LEADERBOARD_TEXT)]
internal class ShowLeaderboardCommand : IMenuCommand
{
    private readonly ILeaderboardWindowController _leaderboardWindowController;

    public ShowLeaderboardCommand(ILeaderboardWindowController leaderboardWindowController)
    {
        _leaderboardWindowController = leaderboardWindowController
            ?? throw new ArgumentNullException(nameof(leaderboardWindowController));
    }

    public string Text => MenuCommands.LEADERBOARD_TEXT;
    public uint Order => 5;

    public void Execute(string[] args)
    {
        _leaderboardWindowController.ShowWindow();
    }
}
