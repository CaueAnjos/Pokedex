using PokedexCLI.Models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace PokedexCLI.Views;

internal class PokemonView : View
{
    public PokemonView(Task<Pokemon> pokemon)
    {
        _task = pokemon;
    }

    private Task<Pokemon> _task;
    private Pokemon _pokemon = new();

    public async Task PrintAsync()
    {
        _pokemon = await _task.Loading().PrintAsync();

        AnsiConsole.Clear();

        Panel panel = new Panel(CreatePokemonLayout())
            .Header($"[bold yellow]:glowing_star: {_pokemon.Name.ToUpper()} #{_pokemon.Id}[/]")
            .Collapse()
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
            $"[bold]Height:[/] [cyan]{_pokemon.Height / 10.0:F1}m[/]",
            $"[bold]Weight:[/] [cyan]{_pokemon.Weight / 10.0:F1}kg[/]",
            $"[bold]Base XP:[/] [cyan]{_pokemon.BaseExperience}[/]"
        );

        return new Panel(table)
            .Header("[bold blue]:bar_chart: Basic Info[/]")
            .Border(BoxBorder.None);
    }

    private Panel CreateTypesPanel()
    {
        if (_pokemon.Types.Any() != true)
        {
            return new Panel("[dim]No type data[/]")
                .Header("[bold green]:label: Types[/]")
                .BorderColor(Color.Green);
        }

        var typeMarkup = new Markup(
            string.Join(
                "\n",
                _pokemon.Types.Select(t =>
                {
                    var emoji = GetTypeEmoji(t.Type.Name);
                    var color = GetTypeColor(t.Type.Name);
                    return $"{emoji} [bold {color}]{t.Type.Name.ToUpper()}[/]";
                })
            )
        );

        return new Panel(typeMarkup)
            .Header("[bold green]:label: Types[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Blue);
    }

    private Panel CreateStatsPanel()
    {
        if (_pokemon.Stats.Any() != true)
        {
            return new Panel("[dim]No stat data[/]")
                .Header("[bold red]:abacus: Stats[/]")
                .BorderColor(Color.Red);
        }

        var barChart = new BarChart().Width(50);

        foreach (var stat in _pokemon.Stats)
        {
            var statName = FormatStatName(stat.Stat.Name);
            var statValue = stat.BaseStat;

            barChart.AddItem(statName, statValue);
        }

        return new Panel(barChart)
            .Header("[bold red]:abacus: Stats[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Red);
    }

    private Panel CreateAbilitiesPanel()
    {
        if (_pokemon.Abilities.Any() != true)
        {
            return new Panel("[dim]No abilities data[/]")
                .Header("[bold yellow]:high_voltage: Abilities[/]")
                .BorderColor(Color.Yellow);
        }

        var content = string.Join(
            "\n",
            _pokemon.Abilities.Select(ability =>
            {
                var hiddenText = ability.IsHidden ? " [dim](Hidden)[/]" : "";
                var abilityName = ability.Ability.Name.Replace("-", " ");
                return $"• [bold white]{abilityName}[/]{hiddenText}";
            })
        );

        return new Panel(new Markup(content))
            .Header("[bold yellow]:high_voltage: Abilities[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Yellow);
    }

    private Panel CreateMovesPanel()
    {
        if (_pokemon.Moves.Any() != true)
        {
            return new Panel("[dim]No moves data[/]")
                .Header("[bold purple]:boxing_glove: Sample Moves[/]")
                .BorderColor(Color.Purple);
        }

        var sampleMoves = _pokemon.Moves.Take(5);
        var content = string.Join(
            "\n",
            sampleMoves.Select(move =>
            {
                var moveName = move.Move.Name.Replace("-", " ");
                return $"• [white]{moveName}[/]";
            })
        );

        if (_pokemon.Moves.Count > 5)
        {
            content += $"\n[dim]... and {_pokemon.Moves.Count - 5} more moves[/]";
        }

        return new Panel(new Markup(content))
            .Header("[bold purple]:boxing_glove: Sample Moves[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Purple);
    }

    private Panel CreateSpritesPanel()
    {
        if (_pokemon.Sprites.FrontDefault == null)
        {
            return new Panel("[dim]No sprite data[/]")
                .Header("[bold cyan]:framed_picture: Sprites[/]")
                .BorderColor(Color.DarkCyan);
        }

        var content = "";
        if (!string.IsNullOrEmpty(_pokemon.Sprites.FrontDefault))
            content += $"[bold]Default:[/] [link]{_pokemon.Sprites.FrontDefault}[/]\n";
        if (!string.IsNullOrEmpty(_pokemon.Sprites.FrontShiny))
            content += $"[bold]Shiny:[/] [link]{_pokemon.Sprites.FrontShiny}[/]";

        return new Panel(new Markup(content.Trim()))
            .Header("[bold cyan]:framed_picture: Sprites[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.DarkCyan);
    }

    private string GetTypeEmoji(string typeName)
    {
        return typeName?.ToLower() switch
        {
            "normal" => ":white_circle:",
            "fire" => ":fire:",
            "water" => ":water_wave:",
            "electric" => ":high_voltage:",
            "grass" => ":leafy_green:",
            "ice" => ":snowflake:",
            "fighting" => ":flexed_biceps:",
            "poison" => ":skull:",
            "ground" => ":globe_showing_americas:",
            "flying" => ":fly:",
            "psychic" => ":brain:",
            "bug" => ":bug:",
            "rock" => ":rock:",
            "ghost" => ":ghost:",
            "dragon" => ":dragon_face:",
            "dark" => ":new_moon_face:",
            "steel" => ":gear:",
            "fairy" => ":fairy:",
            _ => ":red_question_mark:",
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
