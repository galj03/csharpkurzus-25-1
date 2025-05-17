using BSRKB5.Models;

namespace BSRKB5.Windows.Leaderboard;
internal interface ILeaderboardWindow : IWindow
{
    IList<GameResult> GameResults { get; set; }
}