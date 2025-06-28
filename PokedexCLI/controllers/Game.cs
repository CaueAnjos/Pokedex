using PokedexCLI.Models.Game;
using PokedexCLI.Views.Game;
using Spectre.Console;

namespace PokedexCLI.Controllers;

internal sealed class Game
{
    public Game(string? SaveSlot)
    {
        var startMenu = new StartMenuView(GameSave.GetSavedGames().ToList());
        _gameSave = startMenu.Print();
        _gameSave.Save();
    }

    public async Task<int> RunAsync()
    {
        while (true)
        {
            AnsiConsole.Clear();
            SelectActionView selectActionView = new(new List<string> { "Brincar", "Sair" });
            string action = selectActionView.Print();

            switch (action)
            {
                case "Brincar":
                    PetPlayingView petPlayingView = new();
                    await petPlayingView.Print(_gameSave.Pet.Name);
                    break;
                case "Sair":
                    return 0;
            }
        }
    }

    private GameSave _gameSave;
}
