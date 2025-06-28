using Spectre.Console;
using Spectre.Console.Extensions;

namespace PokedexCLI.Views.Game;

internal sealed class PetPlayingView
{
    private sealed class PlayingSpinner : Spinner
    {
        public override TimeSpan Interval => TimeSpan.FromMilliseconds(100);

        public override bool IsUnicode => true;

        public override IReadOnlyList<string> Frames =>
            new List<string>
            {
                " 🧔⚽      🐤",
                "🧔  ⚽     🐤",
                "🧔   ⚽    🐤",
                "🧔    ⚽   🐤",
                "🧔     ⚽  🐤",
                "🧔      ⚽🐥 ",
                "🧔     ⚽  🐤",
                "🧔    ⚽   🐤",
                "🧔   ⚽    🐤",
                "🧔  ⚽     🐤",
                "🧔 ⚽      🐤",
            };
    }

    public async Task Print(string pokemonName)
    {
        await Task.Delay(10000).Spinner(new PlayingSpinner());
        AnsiConsole.Clear();
        AnsiConsole.Markup($"[green]{pokemonName} está feliz![/]  ");
        await Task.Delay(5000).Spinner(Spinner.Known.Smiley);
    }
}
