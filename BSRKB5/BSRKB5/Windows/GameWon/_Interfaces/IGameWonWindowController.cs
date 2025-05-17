namespace BSRKB5.Windows.GameWon;
internal interface IGameWonWindowController : IWindowController
{
    void SetGameTime(TimeSpan gameTime);
}