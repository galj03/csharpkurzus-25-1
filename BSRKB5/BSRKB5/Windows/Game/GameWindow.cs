using BSRKB5.Communication;
using BSRKB5.Services;

namespace BSRKB5.Windows.Game;
internal class GameWindow : IGameWindow
{
    public IGameService GameService { get; }

    private readonly IConsoleOutput _consoleOutput;

    public GameWindow(IConsoleOutput consoleOutput, IGameService gameService)
    {
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
        GameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("Minesweeper App in C# - Game");
        _consoleOutput.WriteLine("----------------------\n");

        _consoleOutput.WriteLine(GameService.GetGameStateAsString());

        _consoleOutput.WriteLine("\nW, A, S, D (or arrows) - Movement");
        _consoleOutput.WriteLine("f - Flag field");
        _consoleOutput.WriteLine("g - Question field");
        _consoleOutput.WriteLine("h - Mark field as safe");
        _consoleOutput.WriteLine("q - Back to menu");
    }
}
