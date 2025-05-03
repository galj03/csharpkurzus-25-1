using BSRKB5.Communication;

namespace BSRKB5.Windows;
internal abstract class WindowController : IWindowController
{
    private readonly IConsoleInput _consoleInput;

    protected WindowController(IConsoleInput consoleInput)
    {
        _consoleInput = consoleInput ?? throw new ArgumentNullException(nameof(consoleInput));
    }

    public void ShowWindow()
    {
        while (true)
        {
            PrintContent();

            var keyInfo = _consoleInput.ReadKey();

            HandleInput(keyInfo);
        }
    }

    protected abstract void PrintContent();
    protected abstract void HandleInput(ConsoleKeyInfo keyInfo);
}
