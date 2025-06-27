namespace PokedexCLI.Models;

internal static class Language
{
    public enum CommandDescriptions
    {
        RootCommand = 0,
    }

    public static Dictionary<CommandDescriptions, string> descriptions = new()
    {
        { CommandDescriptions.RootCommand, "A CLI for Pokedex" },
    };
}
