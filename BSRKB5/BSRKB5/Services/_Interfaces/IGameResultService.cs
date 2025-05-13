using BSRKB5.Models;

namespace BSRKB5.Services;
internal interface IGameResultService
{
    Task SaveResultToFileAsync(GameResult gameResult);

    ICollection<GameResult> LoadResultsFromFile();
}