using BSRKB5.Windows.Game;

namespace BSRKB5.Commands;
[Command("Start Game", Text = "Play")]
internal class StartGameCommand : IMenuCommand
{
    private readonly IGameWindowController _gameWindowController;

    public string Text => "Play";
    public uint Order => 0;

    public StartGameCommand(IGameWindowController gameWindowController)
    {
        _gameWindowController = gameWindowController ?? throw new ArgumentNullException(nameof(gameWindowController));
    }

    public void Execute(string[] args)
    {
        _gameWindowController.ShowWindow();
    }
}
