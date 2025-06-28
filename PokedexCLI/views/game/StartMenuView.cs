using PokedexCLI.Models.Game;
using Spectre.Console;

namespace PokedexCLI.Views.Game;

internal sealed class StartMenuView
{
    public GameSave Print()
    {
        var rule = new Rule("[yellow]Start Menu[/]").LeftJustified();
        AnsiConsole.Write(rule);

        if (SaveSlots is null || SaveSlots.Count == 0)
            return CreateNewGame();

        bool shoudCreateNewGame = AnsiConsole.Prompt(
            new TextPrompt<bool>("Deseja criar um novo jogo?")
                .AddChoice(true)
                .AddChoice(false)
                .DefaultValue(false)
                .WithConverter(choice => choice ? "y" : "n")
        );

        if (shoudCreateNewGame)
            return CreateNewGame();

        return LoadGame();
    }

    public GameSave LoadGame()
    {
        var load = new LoadGameView(SaveSlots!.Select(x => x.Name).ToList());
        string saveSlot = load.Print();
        return SaveSlots!.First(x => x.Name == saveSlot);
    }

    public GameSave CreateNewGame()
    {
        string saveSlot = AnsiConsole.Prompt(
            new TextPrompt<string>("Qual será o nome desse [cyan]Save[/]?")
        );

        string petName = AnsiConsole.Prompt(
            new TextPrompt<string>("Qual será o nome do seu [cyan]pokemon[/]?")
        );

        string petPokemon = AnsiConsole.Prompt(
            new TextPrompt<string>("Que [cyan]pokemon[/] ele é?")
        );

        return new GameSave(saveSlot, new Pet(petName, petPokemon));
    }

    public readonly List<GameSave>? SaveSlots;

    public StartMenuView(List<GameSave>? saveSlots = null)
    {
        SaveSlots = saveSlots;
    }
}
