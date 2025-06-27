using System.Text.Json.Serialization;

namespace PokedexCLI.Models;

#nullable disable
public class Pokemon
{
    [JsonPropertyName("abilities")]
    public List<PokemonAbility> Abilities { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("cries")]
    public Cries Cries { get; set; }

    [JsonPropertyName("forms")]
    public List<NamedApiResource> Forms { get; set; }

    [JsonPropertyName("game_indices")]
    public List<GameIndex> GameIndices { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("held_items")]
    public List<HeldItem> HeldItems { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("location_area_encounters")]
    public string LocationAreaEncounters { get; set; }

    [JsonPropertyName("moves")]
    public List<PokemonMove> Moves { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("past_abilities")]
    public List<PastAbility> PastAbilities { get; set; }

    [JsonPropertyName("past_types")]
    public List<PastType> PastTypes { get; set; }

    [JsonPropertyName("species")]
    public NamedApiResource Species { get; set; }

    [JsonPropertyName("sprites")]
    public Sprites Sprites { get; set; }

    [JsonPropertyName("stats")]
    public List<PokemonStat> Stats { get; set; }

    [JsonPropertyName("types")]
    public List<PokemonType> Types { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}

public class PokemonAbility
{
    [JsonPropertyName("ability")]
    public NamedApiResource Ability { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }
}

public class Cries
{
    [JsonPropertyName("latest")]
    public string Latest { get; set; }

    [JsonPropertyName("legacy")]
    public string Legacy { get; set; }
}

public class GameIndex
{
    [JsonPropertyName("game_index")]
    public int Index { get; set; }

    [JsonPropertyName("version")]
    public NamedApiResource Version { get; set; }
}

public class HeldItem
{
    [JsonPropertyName("item")]
    public NamedApiResource Item { get; set; }

    [JsonPropertyName("version_details")]
    public List<VersionDetail> VersionDetails { get; set; }
}

public class VersionDetail
{
    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("version")]
    public NamedApiResource Version { get; set; }
}

public class PokemonMove
{
    [JsonPropertyName("move")]
    public NamedApiResource Move { get; set; }

    [JsonPropertyName("version_group_details")]
    public List<VersionGroupDetail> VersionGroupDetails { get; set; }
}

public class VersionGroupDetail
{
    [JsonPropertyName("level_learned_at")]
    public int LevelLearnedAt { get; set; }

    [JsonPropertyName("move_learn_method")]
    public NamedApiResource MoveLearnMethod { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("version_group")]
    public NamedApiResource VersionGroup { get; set; }
}

public class PastAbility
{
    [JsonPropertyName("abilities")]
    public List<PokemonAbility> Abilities { get; set; }

    [JsonPropertyName("generation")]
    public NamedApiResource Generation { get; set; }
}

public class PastType
{
    [JsonPropertyName("generation")]
    public NamedApiResource Generation { get; set; }

    [JsonPropertyName("types")]
    public List<PokemonType> Types { get; set; }
}

public class Sprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }

    [JsonPropertyName("other")]
    public OtherSprites Other { get; set; }

    [JsonPropertyName("versions")]
    public VersionSprites Versions { get; set; }
}

public class OtherSprites
{
    [JsonPropertyName("dream_world")]
    public DreamWorldSprites DreamWorld { get; set; }

    [JsonPropertyName("home")]
    public HomeSprites Home { get; set; }

    [JsonPropertyName("official-artwork")]
    public OfficialArtworkSprites OfficialArtwork { get; set; }

    [JsonPropertyName("showdown")]
    public ShowdownSprites Showdown { get; set; }
}

public class DreamWorldSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }
}

public class HomeSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class OfficialArtworkSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }
}

public class ShowdownSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class VersionSprites
{
    [JsonPropertyName("generation-i")]
    public GenerationISprites GenerationI { get; set; }

    [JsonPropertyName("generation-ii")]
    public GenerationIISprites GenerationII { get; set; }

    [JsonPropertyName("generation-iii")]
    public GenerationIIISprites GenerationIII { get; set; }

    [JsonPropertyName("generation-iv")]
    public GenerationIVSprites GenerationIV { get; set; }

    [JsonPropertyName("generation-v")]
    public GenerationVSprites GenerationV { get; set; }

    [JsonPropertyName("generation-vi")]
    public GenerationVISprites GenerationVI { get; set; }

    [JsonPropertyName("generation-vii")]
    public GenerationVIISprites GenerationVII { get; set; }

    [JsonPropertyName("generation-viii")]
    public GenerationVIIISprites GenerationVIII { get; set; }
}

public class GenerationISprites
{
    [JsonPropertyName("red-blue")]
    public RedBlueSprites RedBlue { get; set; }

    [JsonPropertyName("yellow")]
    public YellowSprites Yellow { get; set; }
}

public class RedBlueSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_gray")]
    public string BackGray { get; set; }

    [JsonPropertyName("back_transparent")]
    public string BackTransparent { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_gray")]
    public string FrontGray { get; set; }

    [JsonPropertyName("front_transparent")]
    public string FrontTransparent { get; set; }
}

public class YellowSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_gray")]
    public string BackGray { get; set; }

    [JsonPropertyName("back_transparent")]
    public string BackTransparent { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_gray")]
    public string FrontGray { get; set; }

    [JsonPropertyName("front_transparent")]
    public string FrontTransparent { get; set; }
}

public class GenerationIISprites
{
    [JsonPropertyName("crystal")]
    public CrystalSprites Crystal { get; set; }

    [JsonPropertyName("gold")]
    public GoldSprites Gold { get; set; }

    [JsonPropertyName("silver")]
    public SilverSprites Silver { get; set; }
}

public class CrystalSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_transparent")]
    public string BackShinyTransparent { get; set; }

    [JsonPropertyName("back_transparent")]
    public string BackTransparent { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_transparent")]
    public string FrontShinyTransparent { get; set; }

    [JsonPropertyName("front_transparent")]
    public string FrontTransparent { get; set; }
}

public class GoldSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_transparent")]
    public string FrontTransparent { get; set; }
}

public class SilverSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_transparent")]
    public string FrontTransparent { get; set; }
}

public class GenerationIIISprites
{
    [JsonPropertyName("emerald")]
    public EmeraldSprites Emerald { get; set; }

    [JsonPropertyName("firered-leafgreen")]
    public FireRedLeafGreenSprites FireRedLeafGreen { get; set; }

    [JsonPropertyName("ruby-sapphire")]
    public RubySapphireSprites RubySapphire { get; set; }
}

public class EmeraldSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }
}

public class FireRedLeafGreenSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }
}

public class RubySapphireSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }
}

public class GenerationIVSprites
{
    [JsonPropertyName("diamond-pearl")]
    public DiamondPearlSprites DiamondPearl { get; set; }

    [JsonPropertyName("heartgold-soulsilver")]
    public HeartGoldSoulSilverSprites HeartGoldSoulSilver { get; set; }

    [JsonPropertyName("platinum")]
    public PlatinumSprites Platinum { get; set; }
}

public class DiamondPearlSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class HeartGoldSoulSilverSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class PlatinumSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class GenerationVSprites
{
    [JsonPropertyName("black-white")]
    public BlackWhiteSprites BlackWhite { get; set; }
}

public class BlackWhiteSprites
{
    [JsonPropertyName("animated")]
    public AnimatedSprites Animated { get; set; }

    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class AnimatedSprites
{
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class GenerationVISprites
{
    [JsonPropertyName("omegaruby-alphasapphire")]
    public OmegaRubyAlphaSapphireSprites OmegaRubyAlphaSapphire { get; set; }

    [JsonPropertyName("x-y")]
    public XYSprites XY { get; set; }
}

public class OmegaRubyAlphaSapphireSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class XYSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class GenerationVIISprites
{
    [JsonPropertyName("icons")]
    public IconSprites Icons { get; set; }

    [JsonPropertyName("ultra-sun-ultra-moon")]
    public UltraSunUltraMoonSprites UltraSunUltraMoon { get; set; }
}

public class IconSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }
}

public class UltraSunUltraMoonSprites
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }
}

public class GenerationVIIISprites
{
    [JsonPropertyName("icons")]
    public IconSprites Icons { get; set; }
}

public class PokemonStat
{
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }

    [JsonPropertyName("effort")]
    public int Effort { get; set; }

    [JsonPropertyName("stat")]
    public NamedApiResource Stat { get; set; }
}

public class PokemonType
{
    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("type")]
    public NamedApiResource Type { get; set; }
}

public class NamedApiResource
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
