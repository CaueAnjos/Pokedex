using System.Text.Json;

namespace PokedexCLI.Models.Game;

internal class GameSave
{
    public GameSave(string name, Pet? pet = null)
    {
        Name = name;

        FilePath = GetGameSaveFilePath(name);

        if (pet is not null)
        {
            Pet = pet;
        }
        else
        {
            Pet = new Pet(name);
        }
    }

    public readonly string FilePath;

    public string Name { get; init; }
    public Pet Pet { get; set; }

    public static List<GameSave> SavedGames { get; set; } = new();

    private static string SavesFilePath =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "PokedexCLI"
        );

    private static JsonSerializerOptions _options = new() { WriteIndented = true };

    public void Save()
    {
        Directory.CreateDirectory(SavesFilePath);

        using FileStream fs = File.Create(FilePath);
        JsonSerializer.Serialize(fs, this, _options);
    }

    public static GameSave? Load(string name)
    {
        string filePath = GetGameSaveFilePath(name);
        if (!File.Exists(filePath))
            return null;

        using FileStream fs = File.OpenRead(filePath);
        return JsonSerializer.Deserialize<GameSave>(fs, _options);
    }

    public static void Delete(string name)
    {
        File.Delete(GetGameSaveFilePath(name));
    }

    public static string GetGameSaveFilePath(string name)
    {
        return Path.Combine(SavesFilePath, $"{name}.json");
    }
}
