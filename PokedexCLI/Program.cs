using System.CommandLine;
using PokedexCLI;
using PokedexCLI.Commands;
using PokedexCLI.Models;
using Spectre.Console;
using Spectre.Console.Extensions;

internal class Program
{
    public static Argument<string> nameArgument = new("name");
    public static Option<bool> jsonOption = new("--json");

    private static async Task<int> Main(string[] args)
    {
        RootCommand rootCommand = new("A CLI for Pokedex");

        rootCommand.Options.Add(jsonOption);
        rootCommand.Arguments.Add(nameArgument);

        rootCommand.SetAction(RootCommandAction);

        rootCommand.Subcommands.Add(new TamagotchiCommand());

        ParseResult parseResult = rootCommand.Parse(args);
        return await parseResult.InvokeAsync();
    }

    public static async Task RootCommandAction(ParseResult parseResult)
    {
        PokeApiFacade api = new();
        bool? isJson = parseResult.GetValue(jsonOption);
        if (isJson is not null && isJson.Value)
        {
            string json = await api.GetJsonPokemonInfoAsync(
                    parseResult.GetValue(nameArgument) ?? ""
                )
                .Spinner();
            Console.WriteLine(json);
        }
        else
        {
            Pokemon pokemon = await api.GetPokemonInfoAsync(
                    parseResult.GetValue(nameArgument) ?? ""
                )
                .Spinner();
            pokemon.PrintBeautiful();
        }
    }
}
