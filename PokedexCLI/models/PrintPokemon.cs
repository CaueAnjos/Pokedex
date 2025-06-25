using System.Text;

namespace PokedexCLI.Models;

public partial class Pokemon
{
    public void PrintBeautiful()
    {
        var sb = new StringBuilder();

        // Header with Pokemon name and ID
        sb.AppendLine("╔══════════════════════════════════════════════════════════════╗");
        sb.AppendLine($"║  🌟 {Name?.ToUpper().PadRight(50)} #{Id.ToString().PadLeft(3)} ║");
        sb.AppendLine("╠══════════════════════════════════════════════════════════════╣");

        // Basic Information
        sb.AppendLine("║ 📊 BASIC INFO                                                ║");
        sb.AppendLine(
            $"║    Height: {Height / 10.0:F1}m  |  Weight: {Weight / 10.0:F1}kg  |  Base XP: {BaseExperience}     ║"
        );
        sb.AppendLine("║                                                              ║");

        // Types
        if (Types?.Any() == true)
        {
            sb.AppendLine("║ 🏷️  TYPES                                                     ║");
            var typeStr = string.Join(
                " | ",
                Types.Select(t => GetTypeEmoji(t.Type.Name) + " " + t.Type.Name.ToUpper())
            );
            sb.AppendLine($"║    {typeStr.PadRight(58)} ║");
            sb.AppendLine("║                                                              ║");
        }

        // Stats
        if (Stats?.Any() == true)
        {
            sb.AppendLine("║ 📈 STATS                                                     ║");
            foreach (var stat in Stats)
            {
                var statName = FormatStatName(stat.Stat.Name);
                var statBar = CreateStatBar(stat.BaseStat);
                sb.AppendLine(
                    $"║    {statName}: {stat.BaseStat.ToString().PadLeft(3)} {statBar.PadRight(20)} ║"
                );
            }
            sb.AppendLine("║                                                              ║");
        }

        // Abilities
        if (Abilities?.Any() == true)
        {
            sb.AppendLine("║ ⚡ ABILITIES                                                  ║");
            foreach (var ability in Abilities)
            {
                var hiddenText = ability.IsHidden ? " (Hidden)" : "";
                var abilityName = ability.Ability.Name.Replace("-", " ");
                sb.AppendLine($"║    • {abilityName}{hiddenText}".PadRight(62) + "║");
            }
            sb.AppendLine("║                                                              ║");
        }

        // Moves (show first 5)
        if (Moves?.Any() == true)
        {
            sb.AppendLine("║ 🥊 SAMPLE MOVES                                              ║");
            var sampleMoves = Moves.Take(5);
            foreach (var move in sampleMoves)
            {
                var moveName = move.Move.Name.Replace("-", " ");
                sb.AppendLine($"║    • {moveName}".PadRight(62) + "║");
            }
            if (Moves.Count > 5)
            {
                sb.AppendLine($"║    ... and {Moves.Count - 5} more moves".PadRight(62) + "║");
            }
            sb.AppendLine("║                                                              ║");
        }

        // Sprite URLs (if available)
        if (Sprites?.FrontDefault != null)
        {
            sb.AppendLine("║ 🖼️  SPRITES                                                   ║");
            if (!string.IsNullOrEmpty(Sprites.FrontDefault))
                sb.AppendLine($"║    Default: {Sprites.FrontDefault}".PadRight(62) + "║");
            if (!string.IsNullOrEmpty(Sprites.FrontShiny))
                sb.AppendLine($"║    Shiny:   {Sprites.FrontShiny}".PadRight(62) + "║");
            sb.AppendLine("║                                                              ║");
        }

        sb.AppendLine("╚══════════════════════════════════════════════════════════════╝");

        Console.WriteLine(sb.ToString());
    }

    private string GetTypeEmoji(string typeName)
    {
        return typeName?.ToLower() switch
        {
            "normal" => "⚪",
            "fire" => "🔥",
            "water" => "💧",
            "electric" => "⚡",
            "grass" => "🌿",
            "ice" => "❄️",
            "fighting" => "👊",
            "poison" => "☠️",
            "ground" => "🌍",
            "flying" => "🕊️",
            "psychic" => "🔮",
            "bug" => "🐛",
            "rock" => "🪨",
            "ghost" => "👻",
            "dragon" => "🐉",
            "dark" => "🌙",
            "steel" => "⚙️",
            "fairy" => "🧚",
            _ => "❓",
        };
    }

    private string FormatStatName(string statName)
    {
        return statName?.Replace("-", " ") switch
        {
            "hp" => "HP      ",
            "attack" => "Attack  ",
            "defense" => "Defense ",
            "special attack" => "Sp. Atk ",
            "special defense" => "Sp. Def ",
            "speed" => "Speed   ",
            _ => statName?.PadRight(8) ?? "Unknown ",
        };
    }

    private string CreateStatBar(int statValue)
    {
        // Create a visual stat bar (max stat assumed to be around 200)
        var barLength = Math.Min(statValue / 10, 20);
        var filledBar = new string('█', barLength);
        var emptyBar = new string('░', 20 - barLength);

        return statValue switch
        {
            >= 150 => $"🔴{filledBar}{emptyBar}",
            >= 100 => $"🟡{filledBar}{emptyBar}",
            >= 70 => $"🟢{filledBar}{emptyBar}",
            _ => $"🔵{filledBar}{emptyBar}",
        };
    }
}
