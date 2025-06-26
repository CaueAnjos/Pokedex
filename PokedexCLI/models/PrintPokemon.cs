using Spectre.Console;
using Spectre.Console.Rendering;

namespace PokedexCLI.Models;

public partial class Pokemon
{
    public void PrintBeautiful()
    {
        Panel panel = new Panel(CreatePokemonLayout())
            .Header($"[bold yellow]🌟 {Name.ToUpper()} #{Id}[/]")
            .BorderColor(Color.Gold1)
            .Border(BoxBorder.Double);

        AnsiConsole.Write(panel);
    }

    private Renderable CreatePokemonLayout()
    {
        var layout = new Layout("Root").SplitRows(
            new Layout("BasicInfo").Size(5),
            new Layout("TypesAndStats")
                .SplitColumns(new Layout("Types").Size(20), new Layout("Stats"))
                .MinimumSize(5),
            new Layout("Bottom")
                .SplitColumns(new Layout("Abilities").Size(20), new Layout("Moves"))
                .MinimumSize(5),
            new Layout("Sprites")
        );

        layout["BasicInfo"].Update(CreateBasicInfoPanel());
        layout["Types"].Update(CreateTypesPanel());
        layout["Stats"].Update(CreateStatsPanel());
        layout["Abilities"].Update(CreateAbilitiesPanel());
        layout["Moves"].Update(CreateMovesPanel());
        layout["Sprites"].Update(CreateSpritesPanel());

        return layout;
    }

    private Panel CreateBasicInfoPanel()
    {
        var table = new Table()
            .HideHeaders()
            .Border(TableBorder.None)
            .AddColumn(new TableColumn("").Width(15))
            .AddColumn(new TableColumn("").Width(15))
            .AddColumn(new TableColumn("").Width(15));

        table.AddRow(
            $"[bold]Height:[/] [cyan]{Height / 10.0:F1}m[/]",
            $"[bold]Weight:[/] [cyan]{Weight / 10.0:F1}kg[/]",
            $"[bold]Base XP:[/] [cyan]{BaseExperience}[/]"
        );

        return new Panel(table).Header("[bold blue]📊 Basic Info[/]").Border(BoxBorder.None);
    }

    private Panel CreateTypesPanel()
    {
        if (Types.Any() != true)
        {
            return new Panel("[dim]No type data[/]")
                .Header("[bold green] Types[/]")
                .BorderColor(Color.Green);
        }

        var typeMarkup = new Markup(
            string.Join(
                "\n",
                Types.Select(t =>
                {
                    var emoji = GetTypeEmoji(t.Type.Name);
                    var color = GetTypeColor(t.Type.Name);
                    return $"{emoji} [bold {color}]{t.Type.Name.ToUpper()}[/]";
                })
            )
        );

        return new Panel(typeMarkup)
            .Header("[bold green] Types[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Blue);
    }

    private Panel CreateStatsPanel()
    {
        if (Stats.Any() != true)
        {
            return new Panel("[dim]No stat data[/]")
                .Header("[bold red]📈 Stats[/]")
                .BorderColor(Color.Red);
        }

        var barChart = new BarChart().Width(50);

        foreach (var stat in Stats)
        {
            var statName = FormatStatName(stat.Stat.Name);
            var statValue = stat.BaseStat;

            barChart.AddItem(statName, statValue);
        }

        return new Panel(barChart)
            .Header("[bold red]📈 Stats[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Red);
    }

    private Panel CreateAbilitiesPanel()
    {
        if (Abilities?.Any() != true)
        {
            return new Panel("[dim]No abilities data[/]")
                .Header("[bold yellow]⚡ Abilities[/]")
                .BorderColor(Color.Yellow);
        }

        var content = string.Join(
            "\n",
            Abilities.Select(ability =>
            {
                var hiddenText = ability.IsHidden ? " [dim](Hidden)[/]" : "";
                var abilityName = ability.Ability.Name.Replace("-", " ");
                return $"• [bold white]{abilityName}[/]{hiddenText}";
            })
        );

        return new Panel(new Markup(content))
            .Header("[bold yellow]⚡ Abilities[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Yellow);
    }

    private Panel CreateMovesPanel()
    {
        if (Moves.Any() != true)
        {
            return new Panel("[dim]No moves data[/]")
                .Header("[bold purple]🥊 Sample Moves[/]")
                .BorderColor(Color.Purple);
        }

        var sampleMoves = Moves.Take(5);
        var content = string.Join(
            "\n",
            sampleMoves.Select(move =>
            {
                var moveName = move.Move.Name.Replace("-", " ");
                return $"• [white]{moveName}[/]";
            })
        );

        if (Moves.Count > 5)
        {
            content += $"\n[dim]... and {Moves.Count - 5} more moves[/]";
        }

        return new Panel(new Markup(content))
            .Header("[bold purple]🥊 Sample Moves[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Purple);
    }

    private Panel CreateSpritesPanel()
    {
        if (Sprites.FrontDefault == null)
        {
            return new Panel("[dim]No sprite data[/]")
                .Header("[bold cyan] Sprites[/]")
                .BorderColor(Color.DarkCyan);
        }

        var content = "";
        if (!string.IsNullOrEmpty(Sprites.FrontDefault))
            content += $"[bold]Default:[/] [link]{Sprites.FrontDefault}[/]\n";
        if (!string.IsNullOrEmpty(Sprites.FrontShiny))
            content += $"[bold]Shiny:[/] [link]{Sprites.FrontShiny}[/]";

        return new Panel(new Markup(content.Trim()))
            .Header("[bold cyan] Sprites[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.DarkCyan);
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

    private string GetTypeColor(string typeName)
    {
        return typeName?.ToLower() switch
        {
            "normal" => "grey",
            "fire" => "red",
            "water" => "blue",
            "electric" => "yellow",
            "grass" => "green",
            "ice" => "lightskyblue1",
            "fighting" => "maroon",
            "poison" => "purple",
            "ground" => "olive",
            "flying" => "lightskyblue1",
            "psychic" => "fuchsia",
            "bug" => "lime",
            "rock" => "olive",
            "ghost" => "purple",
            "dragon" => "navy",
            "dark" => "black",
            "steel" => "silver",
            "fairy" => "pink",
            _ => "white",
        };
    }

    private string FormatStatName(string statName)
    {
        return statName?.Replace("-", " ") switch
        {
            "hp" => "HP",
            "attack" => "Attack",
            "defense" => "Defense",
            "special attack" => "Sp. Atk",
            "special defense" => "Sp. Def",
            "speed" => "Speed",
            _ => statName ?? "Unknown",
        };
    }
}
