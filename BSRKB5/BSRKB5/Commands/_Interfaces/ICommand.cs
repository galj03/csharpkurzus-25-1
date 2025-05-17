namespace BSRKB5.Commands;
public interface ICommand
{
    void Execute(params string[] args);
}
