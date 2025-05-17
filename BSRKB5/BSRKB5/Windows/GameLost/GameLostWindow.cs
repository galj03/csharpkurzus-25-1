using BSRKB5.Communication;

namespace BSRKB5.Windows.GameLost;
internal class GameLostWindow : IGameLostWindow
{

    private readonly IConsoleOutput _consoleOutput;

    public GameLostWindow(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("Minesweeper App in C# - Game");
        _consoleOutput.WriteLine("----------------------\n");

        _consoleOutput.WriteLine("\nYou lost the game.");

        _consoleOutput.WriteLine("\nq - Back to menu");
    }
}
