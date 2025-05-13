using BSRKB5.Communication;

namespace BSRKB5.Windows;
internal abstract class WindowController : IWindowController
{
    private readonly IConsoleInput _consoleInput;

    protected WindowController(IConsoleInput consoleInput)
    {
        _consoleInput = consoleInput ?? throw new ArgumentNullException(nameof(consoleInput));
    }

    public virtual void ShowWindow()
    {
        while (true)
        {
            PrintContent();

            var keyInfo = _consoleInput.ReadKey();

            HandleInput(keyInfo, out bool isExit);

            if (isExit)
            {
                break;
            }
        }
    }

    protected abstract void PrintContent();
    protected abstract void HandleInput(ConsoleKeyInfo keyInfo, out bool isExit);
}
