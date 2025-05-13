using System.Text.Json;

using BSRKB5.Extensions;
using BSRKB5.Models;

namespace BSRKB5.Services;

internal class GameResultService : IGameResultService
{
    private readonly string _jsonFileLocation;

    public GameResultService(string jsonFileLocation)
    {
        if (string.IsNullOrWhiteSpace(jsonFileLocation))
        {
            throw new ArgumentException($"'{nameof(jsonFileLocation)}' cannot be null or whitespace.", nameof(jsonFileLocation));
        }

        _jsonFileLocation = jsonFileLocation;
    }

    public ICollection<GameResult> LoadResultsFromFile()
    {
        using var stream = File.OpenRead(_jsonFileLocation);
        var jsonGameResultCollection = JsonSerializer.Deserialize<List<JsonGameResultDto>>(stream) ?? [];

        var gameResultCollection = jsonGameResultCollection
            .AsParallel()
            .Select(jgr => jgr.ToDomainObject())
            .ToList();

        return gameResultCollection;
    }

    public async Task SaveResultToFileAsync(GameResult gameResult)
    {
        var gameResultCollection = LoadResultsFromFile();
        gameResultCollection.Add(gameResult);

        var jsonGameResultCollection = gameResultCollection
            .AsParallel()
            .Select(gr => gr.ToJsonDto())
            .ToList();

        var tempFileLocation = Path.Combine(Path.GetTempPath(), "tempGameResults.json");
        await SaveResultToTempFileAsync(tempFileLocation, jsonGameResultCollection);

        File.Move(tempFileLocation, _jsonFileLocation, true);
    }

    private static async Task SaveResultToTempFileAsync(string tempFileLocation, List<JsonGameResultDto> jsonGameResultCollection)
    {
        using var output = File.Create(tempFileLocation);

        await JsonSerializer.SerializeAsync<List<JsonGameResultDto>>(output, jsonGameResultCollection);
    }
}