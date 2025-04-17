namespace BSRKB5.Commands;
internal interface ICommand
{
    CommandType CommandType { get; }

    void Execute(string[] args);
}
