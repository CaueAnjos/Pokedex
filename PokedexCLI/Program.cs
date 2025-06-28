using PokedexCLI.Controllers.Commands;
using Spectre.Console.Cli;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var app = new CommandApp();
        app.Configure(config =>
        {
            config
                .AddCommand<LookCommand>("look")
                .WithAlias("info")
                .WithDescription("Consulta informações sobre o pokemon")
                .WithExample("look", "pikachu", "--json")
                .WithExample("info", "pikachu");

            config.AddCommand<GameCommand>("game").IsHidden();
        });
        return await app.RunAsync(args);
    }
}
