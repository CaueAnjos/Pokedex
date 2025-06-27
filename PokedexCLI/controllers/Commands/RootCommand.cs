using System.CommandLine;
using PokedexCLI.Models;

namespace PokedexCLI.Controllers.Commands;

internal class RootCommand : System.CommandLine.RootCommand
{
    public RootCommand()
        : base(Language.descriptions[Language.CommandDescriptions.RootCommand])
    {
        _nameArgument = new("name");
        _jsonOption = new("--json");

        Options.Add(_jsonOption);
        Arguments.Add(_nameArgument);

        SetAction(RootCommandAction);
    }

    private readonly Argument<string> _nameArgument;
    private readonly Option<bool> _jsonOption;

    public async Task RootCommandAction(ParseResult parseResult)
    {
        PokeApiFacade api = new();
        bool? isJson = parseResult.GetValue(_jsonOption);
        if (isJson is not null && isJson.Value == true)
        {
            await CommandController.RootView(
                api.GetJsonPokemonInfoAsync(parseResult.GetValue(_nameArgument) ?? "")
            );
        }
        else
        {
            await CommandController.RootView(
                api.GetPokemonInfoAsync(parseResult.GetValue(_nameArgument) ?? "")
            );
        }
    }
}
