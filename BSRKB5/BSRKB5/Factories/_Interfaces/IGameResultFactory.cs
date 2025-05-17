using BSRKB5.Models;

namespace BSRKB5.Factories;
internal interface IGameResultFactory
{
    GameResult Create(string name, TimeSpan gameTime);
}
