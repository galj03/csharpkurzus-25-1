namespace BSRKB5.Commands;
public interface ICommand
{
    CommandType CommandType { get; }

    void Execute(params string[] args);
}
