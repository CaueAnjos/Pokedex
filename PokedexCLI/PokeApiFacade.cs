using System.Text.Json;
using PokedexCLI.Models;

namespace PokedexCLI;

internal class PokeApiFacade
{
    public PokeApiFacade()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

        _options = new JsonSerializerOptions();
        _options.WriteIndented = true;
    }

    ~PokeApiFacade()
    {
        _client.Dispose();
    }

    private HttpClient _client;
    private JsonSerializerOptions _options;

    public async Task<string> GetJsonPokemonInfoAsync(string name)
    {
        Pokemon? pokemon = await GetPokemonInfoAsync(name);
        return JsonSerializer.Serialize(pokemon, _options);
    }

    public async Task<Pokemon> GetPokemonInfoAsync(string name)
    {
        var response = await _client.GetStringAsync($"pokemon/{name}");
        Pokemon? pokemon = JsonSerializer.Deserialize<Pokemon>(response);

        if (pokemon is null)
            throw new Exception("Pokemon not found");

        return pokemon;
    }

    public async Task<string> GetJsonPokemonListAsync()
    {
        List<Pokemon>? pokemons = await GetPokemonListAsync();
        return JsonSerializer.Serialize(pokemons, _options);
    }

    public async Task<List<Pokemon>> GetPokemonListAsync()
    {
        var response = await _client.GetStringAsync($"pokemon");
        List<Pokemon>? pokemons = JsonSerializer.Deserialize<List<Pokemon>>(response);

        if (pokemons is null)
            throw new Exception("Pokemons not found");

        return pokemons;
    }
}
