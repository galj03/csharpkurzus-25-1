using BSRKB5.Communication;

namespace BSRKB5.Windows.Leaderboard;
internal class LeaderboardWindow : ILeaderboardWindow
{
    private readonly IConsoleOutput _consoleOutput;

    public LeaderboardWindow(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("TODO: leaderboard");
        //throw new NotImplementedException();
    }
}
