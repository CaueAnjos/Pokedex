using Spectre.Console;

namespace PokedexCLI.Views.Game;

internal sealed class SelectActionView
{
    public SelectActionView(List<string> actions)
    {
        Actions = actions;
    }

    public string Print()
    {
        string action = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("O que você quer fazer com o seu [cyan]pokemon[/]?")
                .AddChoices(Actions)
        );
        return action;
    }

    public List<string> Actions { get; set; }
}
