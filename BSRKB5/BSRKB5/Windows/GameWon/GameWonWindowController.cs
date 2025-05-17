using BSRKB5.Communication;
using BSRKB5.Factories;
using BSRKB5.Services;

namespace BSRKB5.Windows.GameWon;
internal class GameWonWindowController : IGameWonWindowController
{
    private readonly IConsoleInput _consoleInput;
    private readonly IGameWonWindow _gameWonWindow;
    private readonly IGameResultService _gameResultService;
    private readonly IGameResultFactory _gameResultFactory;
    private TimeSpan _gameTime;

    public GameWonWindowController(
        IConsoleInput consoleInput,
        IGameWonWindow gameWonWindow,
        IGameResultService gameResultService,
        IGameResultFactory gameResultFactory)
    {
        _consoleInput = consoleInput ?? throw new ArgumentNullException(nameof(consoleInput));
        _gameWonWindow = gameWonWindow ?? throw new ArgumentNullException(nameof(gameWonWindow));
        _gameResultService = gameResultService ?? throw new ArgumentNullException(nameof(gameResultService));
        _gameResultFactory = gameResultFactory ?? throw new ArgumentNullException(nameof(gameResultFactory));
    }

    public void SetGameTime(TimeSpan gameTime)
    {
        _gameTime = gameTime;
    }

    public void ShowWindow()
    {
        PrintContent();

        var playerName = _consoleInput.ReadLine();
        var gameResult = _gameResultFactory.Create(playerName, _gameTime);

        Task.Run(async () =>
        {
            await _gameResultService.SaveResultToFileAsync(gameResult);
        });
    }

    protected void PrintContent()
    {
        _gameWonWindow.PrintContent();
    }
}
