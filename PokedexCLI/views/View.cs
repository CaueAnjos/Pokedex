namespace PokedexCLI.Views;

internal interface View
{
    public Task PrintAsync();
}

internal interface View<T>
{
    public Task<T> PrintAsync();
}
