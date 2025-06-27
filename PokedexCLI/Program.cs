using PokedexCLI.Controllers;
using Spectre.Console;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        try
        {
            return await CommandController.RunAsync(args);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(
                ex,
                ExceptionFormats.ShortenEverything | ExceptionFormats.ShowLinks
            );
            return ex.HResult;
        }
    }
}
