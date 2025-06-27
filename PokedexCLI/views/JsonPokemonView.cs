using Spectre.Console;
using Spectre.Console.Extensions;
using Spectre.Console.Json;

namespace PokedexCLI.Views;

internal class JsonPokemonView : View
{
    public JsonPokemonView(Task<string> getJsonPokemonInfoTask)
    {
        _task = getJsonPokemonInfoTask;
    }

    private Task<string> _task;

    public async Task PrintAsync()
    {
        AnsiConsole.MarkupLine("[yellow]Loading json...[/]");
        var json = new JsonText(await _task.Spinner());
        AnsiConsole.Write(
            new Panel(json).Header("JSON").Collapse().RoundedBorder().BorderColor(Color.Yellow)
        );
    }
}
