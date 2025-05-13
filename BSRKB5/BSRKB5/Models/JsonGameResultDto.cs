using System.Text.Json.Serialization;

namespace BSRKB5.Models;

public class JsonGameResultDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("time")]
    public TimeSpan Time { get; set; }
}