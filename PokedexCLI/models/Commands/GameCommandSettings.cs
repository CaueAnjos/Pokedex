using System.ComponentModel;
using Spectre.Console.Cli;

namespace PokedexCLI.Models.Commands;

internal sealed class GameCommandSettings : CommandSettings
{
    [Description("O nome do jogo que será salvo")]
    [CommandOption("-s|--save")]
    public string? SaveSlot { get; set; }
}
