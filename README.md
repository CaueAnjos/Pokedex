# Pokedex CLI Tool

A command-line Pokédex application built in C# that allows you to look up information about your favorite Pokémon using the [PokéAPI](https://pokeapi.co/api/v2/).

## Features

- 🔍 Look up detailed Pokémon information
- 📊 Output data in JSON format
- 🎮 Hidden Tamagotchi-style mini-game
- 🚀 Easy installation as a .NET global tool

## Installation

Install the tool globally using the .NET CLI:

```bash
dotnet tool install pokedex
```

## Usage

### Basic Syntax

```
pokedex [OPÇÕES] <COMANDO>
```

### Commands

#### `look <pokemon>`
Retrieves and displays information about the specified Pokémon.

**Examples:**
```bash
# Get basic Pokémon information
pokedex look pikachu

# Get detailed information in JSON format
pokedex look pikachu --json

# Look up other Pokémon
pokedex look charizard
pokedex look bulbasaur --json
```

#### `info <pokemon>`
Alternative command to get Pokémon information.

**Example:**
```bash
pokedex info pikachu
```

#### `game` (Hidden Command)
Starts a simple Tamagotchi-style mini-game. This is an easter egg feature!

```bash
pokedex game
```

### Options

- `-h, --help`: Display help information and usage examples

## Data Source

This application uses the [PokéAPI](https://pokeapi.co/api/v2/), a free and open RESTful API that provides comprehensive Pokémon data including:

- Basic Pokémon stats
- Abilities and moves
- Types and evolution chains
- Sprites and artwork
- And much more!

## Examples

```bash
# Quick lookup
pokedex look mew

# Get raw JSON data for processing
pokedex look mew --json

# Display help
pokedex --help

# Secret mini-game
pokedex game
```

## Requirements

- .NET 8 Runtime (compatible with the version used to build this tool)
- Internet connection (required for API calls to PokéAPI)

## **Architecture**

This Pokedex CLI tool is built using modern C# practices and follows a clean, maintainable architecture:

### Design Patterns

**MVC (Model-View-Controller) Architecture**
- **Models**: Complete Pokemon data model that mirrors the PokéAPI structure
- **Views**: Rich console interface powered by [Spectre.Console](https://spectreconsole.net/)
- **Controllers**: Command handlers that orchestrate data retrieval and presentation

**Facade Pattern**
The application uses a facade pattern to simplify interactions with the PokéAPI:

```csharp
internal class PokeApiFacade
{
    // Simplified interface for complex PokéAPI operations
    public async Task<Pokemon> GetPokemonInfoAsync(string name)
    public async Task<string> GetJsonPokemonInfoAsync(string name)
    public async Task<List<Pokemon>> GetPokemonListAsync()
}
```

### Key Components

**PokeApiFacade**
- Encapsulates all HTTP communication with PokéAPI
- Handles JSON serialization/deserialization
- Provides both typed objects and raw JSON responses
- Manages HttpClient lifecycle and base configuration

**Pokemon Model**
- Comprehensive data class representing the complete PokéAPI Pokemon structure
- Ensures type safety and IntelliSense support
- Mirrors the official API schema for seamless data mapping

**Spectre.Console Integration**
- Powers the rich console user interface
- Provides colorful, formatted output
- Enhances user experience with modern CLI aesthetics

### Technical Features

- **Async/Await**: Full asynchronous operation for responsive API calls
- **JSON Serialization**: Built-in System.Text.Json for efficient data handling
- **Error Handling**: Graceful handling of API failures and invalid requests
- **Resource Management**: Proper disposal of HTTP resources via destructor

## Contributing

Feel free to contribute to this project by submitting issues or pull requests!

## License

This project uses data from [PokéAPI](https://pokeapi.co/), which provides free Pokémon data for developers.

---

*Gotta catch 'em all! 🎯*
