using Acerto.Business.Entities;
using Acerto.Business.Repositories;

namespace Acerto.Business.Services
{
    public class PokedexService : IPokedexService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokedexService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Guid?> AddPokemonAsync(Pokemon pokemon)
        {
            var validation = pokemon.Validate();

            if (!validation.IsValid)
            {
                // Noticar um erro para o meu usuário
                return null;
            }

            var registredPokemon = await _pokemonRepository.GetByNameAsync(pokemon.Name);

            if (registredPokemon != null)
            {
                // Notificar a inconsistência para o meu usuário
                return null;
            }

            await _pokemonRepository.AddAsync(pokemon);

            return pokemon.Id;
        }

        public async Task UpdatePokemonAsync(Pokemon pokemon)
        {
            var validation = pokemon.Validate();

            if (!validation.IsValid)
            {
                // Noticar um erro para o meu usuário
                return;
            }

            var hasPokemon = await _pokemonRepository.HasPokemonAsync(pokemon.Id);

            if (!hasPokemon)
            {
                // Noticar um erro para o meu usuário
                return;
            }

            var registredPokemon = await _pokemonRepository.GetByNameAsync(pokemon.Name);

            if (registredPokemon != null && registredPokemon.Id != pokemon.Id)
            {
                // Notificar a inconsistência para o meu usuário
                return;
            }

            _pokemonRepository.Update(pokemon);
        }

        public async Task DeletePokemonAsync(Guid pokemonId)
        {
            var hasPokemon = await _pokemonRepository.HasPokemonAsync(pokemonId);

            if (!hasPokemon)
            {
                // Noticar um erro para o meu usuário
                return;
            }

            _pokemonRepository.Delete(pokemonId);
        }
    }
}