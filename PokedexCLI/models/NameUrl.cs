using System.Text.Json.Serialization;

namespace PokedexCLI.Models;

internal class NameUrl
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
