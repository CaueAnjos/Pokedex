using System.CommandLine;
using PokedexCLI;
using PokedexCLI.Commands;
using PokedexCLI.Models;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        RootCommand rootCommand = new("A CLI for Pokedex");

        Argument<string> nameArgument = new("Pokemon name");
        Option<bool> jsonOption = new("--json");

        rootCommand.Options.Add(jsonOption);
        rootCommand.Arguments.Add(nameArgument);

        PokeApiFacade api = new();
        rootCommand.SetAction(
            async (parseResult) =>
            {
                bool? isJson = parseResult.GetValue(jsonOption);
                if (isJson is not null && isJson.Value)
                {
                    string json = await api.GetJsonPokemonInfoAsync(
                        parseResult.GetValue(nameArgument) ?? ""
                    );
                    Console.WriteLine(json);
                }
                else
                {
                    Pokemon pokemon = await api.GetPokemonInfoAsync(
                        parseResult.GetValue(nameArgument) ?? ""
                    );
                    pokemon.PrintBeautiful();
                }
            }
        );

        rootCommand.Subcommands.Add(new TamagotchiCommand());

        ParseResult parseResult = rootCommand.Parse(args);
        return await parseResult.InvokeAsync();
    }
}
