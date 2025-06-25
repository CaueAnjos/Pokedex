using System.Text;
using System.Text.Json.Serialization;

namespace PokedexCLI.Models;

internal class Pokemon
{
    [JsonPropertyName("abilities")]
    public List<Ability>? Abilities { get; set; }

    public override string ToString()
    {
        if (Abilities is null)
            return "Pokemon: null";

        StringBuilder str = new("Pokemon: ");
        foreach (Ability ability in Abilities)
        {
            str.Append(ability.Name?.Name).Append(" ");
        }

        return str.ToString();
    }
}
