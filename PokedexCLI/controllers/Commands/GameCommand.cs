using PokedexCLI.Models.Commands;
using Spectre.Console.Cli;

namespace PokedexCLI.Controllers.Commands;

internal sealed class GameCommand : AsyncCommand<GameCommandSettings>
{
    public override async Task<int> ExecuteAsync(
        CommandContext context,
        GameCommandSettings settings
    )
    {
        var game = new Game(settings.SaveSlot);
        return await game.RunAsync();
    }
}
