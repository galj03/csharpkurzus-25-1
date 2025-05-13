using BSRKB5.Models;

namespace BSRKB5.Factories;
internal interface IGameStateFactory
{
    GameState Create(int height, int width, int bombs);
}