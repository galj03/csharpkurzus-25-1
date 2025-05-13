using BSRKB5.Services;

namespace BSRKB5.Windows.Game;
internal interface IGameWindow : IWindow
{
    IGameService GameService { get; }
}