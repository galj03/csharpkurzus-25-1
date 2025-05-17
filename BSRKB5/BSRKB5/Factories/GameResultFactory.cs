using BSRKB5.Models;

namespace BSRKB5.Factories;
internal class GameResultFactory : IGameResultFactory
{
    public GameResult Create(string name, TimeSpan gameTime)
    {
        return new GameResult(name, gameTime);
    }
}
