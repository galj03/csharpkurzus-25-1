using BSRKB5.Windows.Game;

using static BSRKB5.Constants;

namespace BSRKB5.Commands;
[Command("Start Game", Text = MenuCommands.START_GAME_TEXT)]
internal class StartGameCommand : IMenuCommand
{
    private readonly IGameWindowController _gameWindowController;

    public string Text => MenuCommands.START_GAME_TEXT;
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
