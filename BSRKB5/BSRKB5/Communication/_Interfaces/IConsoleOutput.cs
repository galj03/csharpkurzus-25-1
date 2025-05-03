namespace BSRKB5.Communication;
internal interface IConsoleOutput
{
    void Clear();
    void Write(string message);

    void WriteLine(string message = "")
    {
        Write(message + Environment.NewLine);
    }
}
