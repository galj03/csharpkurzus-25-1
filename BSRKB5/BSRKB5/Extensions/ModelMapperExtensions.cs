using BSRKB5.Models;

namespace BSRKB5.Extensions;
public static class ModelMapperExtensions
{
    public static JsonGameResultDto ToJsonDto(this GameResult gameResult)
    {
        return new JsonGameResultDto
        {
            Name = gameResult.Name,
            Time = gameResult.Time,
        };
    }

    public static GameResult ToDomainObject(this JsonGameResultDto gameResultDto)
    {
        return new GameResult(gameResultDto.Name, gameResultDto.Time);
    }
}
