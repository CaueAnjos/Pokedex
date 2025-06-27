using PokedexCLI.Controllers.Commands;
using PokedexCLI.Models;
using PokedexCLI.Views;

namespace PokedexCLI.Controllers;

internal static class CommandController
{
    public static readonly RootCommand Root = new RootCommand();

    public static async Task RootView(Task<string> json)
    {
        JsonPokemonView view = new(json);
        await view.PrintAsync();
    }

    public static async Task RootView(Task<Pokemon> pokemon)
    {
        await Task.Delay(50);
        throw new NotImplementedException();
    }

    public static async Task<int> RunAsync(string[] args)
    {
        return await Root.Parse(args).InvokeAsync();
    }
}
