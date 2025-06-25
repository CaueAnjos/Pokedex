using System.Text.Json.Serialization;

namespace PokedexCLI.Models;

internal class Ability
{
    [JsonPropertyName("ability")]
    public NameUrl? Name { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }
}
