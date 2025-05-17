using BSRKB5.Communication;

namespace BSRKB5.Windows.GameWon;
internal class GameWonWindow : IGameWonWindow
{

    private readonly IConsoleOutput _consoleOutput;

    public GameWonWindow(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput ?? throw new ArgumentNullException(nameof(consoleOutput));
    }

    public void PrintContent()
    {
        _consoleOutput.Clear();
        _consoleOutput.WriteLine("Minesweeper App in C# - Game");
        _consoleOutput.WriteLine("----------------------\n");

        _consoleOutput.WriteLine("\nYou won the game.");
        _consoleOutput.Write("Enter your name to save your time result: ");
    }
}
