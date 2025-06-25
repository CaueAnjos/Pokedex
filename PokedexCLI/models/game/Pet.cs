namespace PokedexCLI.Models.Game;

internal class Pet
{
    public Pet(string name, string pokemonName = "pikachu", PetStatus status = PetStatus.Happy)
    {
        Name = name;
        PokemonName = pokemonName;
        Status = status;
    }

    public string Name { get; init; }
    public string PokemonName { get; init; }

    public PetStatus Status { get; set; }

    public async Task<Pokemon> GetPokemon()
    {
        PokeApiFacade api = new();
        return await api.GetPokemonInfoAsync(PokemonName);
    }
}
