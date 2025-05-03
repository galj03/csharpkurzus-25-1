namespace BSRKB5.Commands;
internal interface IMenuCommand : ICommand
{
    uint Order { get; }
    string Text { get; }
}
