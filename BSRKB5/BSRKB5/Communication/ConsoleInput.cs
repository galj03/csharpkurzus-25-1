namespace BSRKB5.Communication;
internal class ConsoleInput : IConsoleInput
{
    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }
}
