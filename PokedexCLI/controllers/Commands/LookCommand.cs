using PokedexCLI.Models;
using PokedexCLI.Models.Commands;
using PokedexCLI.Views;
using Spectre.Console.Cli;

namespace PokedexCLI.Controllers.Commands;

internal sealed class LookCommand : AsyncCommand<LookCommandSettings>
{
    public override async Task<int> ExecuteAsync(
        CommandContext context,
        LookCommandSettings settings
    )
    {
        PokeApiFacade api = new();
        if (settings.PrintInJsonFormat)
        {
            Task<string> jsonTask = api.GetJsonPokemonInfoAsync(settings.PokemonName);
            JsonPokemonView view = new(jsonTask);
            await view.PrintAsync();
        }
        else
        {
            Task<Pokemon> pokemonTask = api.GetPokemonInfoAsync(settings.PokemonName);
            PokemonView view = new(pokemonTask);
            await view.PrintAsync();
        }
        return 0;
    }
}
