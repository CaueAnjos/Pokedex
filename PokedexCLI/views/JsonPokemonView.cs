using Spectre.Console;
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
        string jsonStr = await _task
            .Loading()
            .WithLoadingMessage("[gray]Getting pokemon info...[/]")
            .PrintAsync();
        var json = new JsonText(jsonStr);
        AnsiConsole.Write(
            new Panel(json).Header("JSON").Collapse().RoundedBorder().BorderColor(Color.Yellow)
        );
    }
}
