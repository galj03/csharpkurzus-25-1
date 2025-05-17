namespace BSRKB5.Communication;
internal class ConsoleOutput : IConsoleOutput
{
    public void Clear()
    {
        Console.Clear();
    }

    public void Write(string message)
    {
        Console.Write(message);
    }
}
