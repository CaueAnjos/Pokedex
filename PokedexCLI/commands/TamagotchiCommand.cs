using System.CommandLine;
using Dumpify;
using PokedexCLI.Models.Game;

namespace PokedexCLI.Commands;

internal class TamagotchiCommand : Command
{
    public TamagotchiCommand()
        : base("tamagotchi", "Starts a tamagotchi game!")
    {
        Aliases.Add("game");

        Option<string> gameNameOption = new("--game-name", "--game", "-g") { Required = true };
        Option<string?> petNameOption = new("--pet-name", "--name", "-n");
        Option<string?> pokemonNameOption = new("--pokemon-name", "--pokemon", "-p");

        Options.Add(gameNameOption);
        Options.Add(petNameOption);
        Options.Add(pokemonNameOption);

        Command removeCommand = new("remove", "Removes a game");
        removeCommand.Options.Add(gameNameOption);
        removeCommand.SetAction(
            (parseResult) =>
            {
                GameSave.Delete(parseResult.GetRequiredValue(gameNameOption));
            }
        );
        Subcommands.Add(removeCommand);

        SetAction(
            (parseResult) =>
            {
                string gameName = parseResult.GetRequiredValue(gameNameOption);

                GameSave? gameSave = GameSave.Load(gameName);
                if (gameSave is null)
                {
                    string petName = parseResult.GetValue(petNameOption) ?? gameName;
                    string pokemonName = parseResult.GetValue(pokemonNameOption) ?? "pikachu";

                    gameSave = new GameSave(gameName, new Pet(petName, pokemonName));
                }

                gameSave.Save();
                gameSave.Dump();
            }
        );
    }
}
