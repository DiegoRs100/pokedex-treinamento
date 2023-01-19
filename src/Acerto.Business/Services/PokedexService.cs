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

        public Task UpdatePokemonAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public Task DeletePokemonAsync(Guid pokemonId)
        {
            throw new NotImplementedException();
        }
    }
}