using Spectre.Console;

namespace PokedexCLI.Views.Game;

internal sealed class LoadGameView
{
    public LoadGameView(List<string> saveSlots)
    {
        SaveSlots = saveSlots;
    }

    public string Print()
    {
        string saveSlot = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Que jogo eu devo carregar:")
                .PageSize(10)
                .MoreChoicesText("[grey](Mova para cime ou para baixo para revelar mais opções)[/]")
                .AddChoices(SaveSlots)
        );
        return saveSlot;
    }

    public readonly List<string> SaveSlots;
}
