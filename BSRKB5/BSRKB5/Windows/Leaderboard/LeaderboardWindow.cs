using BSRKB5.Communication;
using BSRKB5.Services;

namespace BSRKB5.Windows.Leaderboard;
internal class LeaderboardWindow : ILeaderboardWindow
{
    private readonly IConsoleOutput _consoleOutput;
    private readonly IGameResultService _gameResultService;

    public LeaderboardWindow(IConsoleOutput consoleOutput, IGameResultService gameResultService)
    {
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
        _gameResultService = gameResultService ?? throw new ArgumentNullException(nameof(gameResultService));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("Minesweeper App in C# - Leaderboard");
        _consoleOutput.WriteLine("----------------------\n");

        _consoleOutput.WriteLine("TOP 10:\n");

        var gameResults = _gameResultService.LoadResultsFromFile().OrderBy(gr => gr.Time).ToList();
        var leaderboardMembersCount = Math.Min(gameResults.Count, 10);
        for (int i = 0; i < leaderboardMembersCount; i++)
        {
            _consoleOutput.WriteLine($"{i+1}. {gameResults[i].Name} - {gameResults[i].Time}");
        }

        _consoleOutput.WriteLine("\nTODO: footer");
    }
}
