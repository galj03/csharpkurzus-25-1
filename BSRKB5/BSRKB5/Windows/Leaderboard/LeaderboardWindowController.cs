using BSRKB5.Communication;

namespace BSRKB5.Windows.Leaderboard;
internal class LeaderboardWindowController : WindowController, ILeaderboardWindowController
{
    private readonly ILeaderboardWindow _leaderboardWindow;

    public LeaderboardWindowController(
        IConsoleInput consoleInput,
        ILeaderboardWindow leaderboardWindow)
        : base(consoleInput)
    {
        _leaderboardWindow = leaderboardWindow ?? throw new ArgumentNullException(nameof(leaderboardWindow));
    }

    protected override void HandleInput(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Q:
            case ConsoleKey.Escape:
                //TODO: back to menu with no memory leaks
                //TODO: do this with commands as well?
                break;
        }
    }

    protected override void PrintContent()
    {
        _leaderboardWindow.PrintContent();
    }
}
