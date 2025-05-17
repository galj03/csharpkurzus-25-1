using BSRKB5.Communication;
using BSRKB5.Models;

namespace BSRKB5.Windows.Leaderboard;
internal class LeaderboardWindow : ILeaderboardWindow
{
    public IList<GameResult> GameResults { get; set; } = [];

    private readonly IConsoleOutput _consoleOutput;

    public LeaderboardWindow(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("Minesweeper App in C# - Leaderboard");
        _consoleOutput.WriteLine("----------------------\n");

        _consoleOutput.WriteLine("TOP 10:\n");

        var leaderboardMembersCount = Math.Min(GameResults.Count, 10);
        for (int i = 0; i < leaderboardMembersCount; i++)
        {
            var gameTime = GameResults[i].Time;
            _consoleOutput.WriteLine($"{i + 1}. {GameResults[i].Name} - {gameTime.ToString(@"mm\:ss")}");
        }

        _consoleOutput.WriteLine("\nq - Back to menu");
    }
}
