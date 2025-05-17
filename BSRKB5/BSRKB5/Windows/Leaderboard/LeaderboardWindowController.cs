using BSRKB5.Communication;
using BSRKB5.Services;

namespace BSRKB5.Windows.Leaderboard;
internal class LeaderboardWindowController : WindowController, ILeaderboardWindowController
{
    private readonly ILeaderboardWindow _leaderboardWindow;
    private readonly IGameResultService _gameResultService;

    public LeaderboardWindowController(
        IConsoleInput consoleInput,
        ILeaderboardWindow leaderboardWindow,
        IGameResultService gameResultService)
        : base(consoleInput)
    {
        _leaderboardWindow = leaderboardWindow ?? throw new ArgumentNullException(nameof(leaderboardWindow));
        _gameResultService = gameResultService;
    }

    public override void ShowWindow()
    {
        var gameResults = _gameResultService.LoadResultsFromFile().OrderBy(gr => gr.Time).ToList();
        _leaderboardWindow.GameResults = gameResults;

        base.ShowWindow();
    }

    protected override void HandleInput(ConsoleKeyInfo keyInfo, out bool isExit)
    {
        isExit = false;

        switch (keyInfo.Key)
        {
            case ConsoleKey.Q:
            case ConsoleKey.Escape:
                isExit = true;
                break;
        }
    }

    protected override void PrintContent()
    {
        _leaderboardWindow.PrintContent();
    }
}
