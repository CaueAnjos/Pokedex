using System.ComponentModel;
using Spectre.Console.Cli;

namespace PokedexCLI.Models.Commands;

internal sealed class LookCommandSettings : CommandSettings
{
    [Description("O nome do pokemon que será consultado")]
    [CommandArgument(0, "<pokemon>")]
    public string PokemonName { get; set; } = string.Empty;

    [Description("Especifica se as informações serão exibidas no formato JSON")]
    [CommandOption("-j|--json")]
    public bool PrintInJsonFormat { get; set; } = false;
}
