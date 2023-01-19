using Acerto.Business.Entities;
using Acerto.Business.Repositories;

namespace Acerto.Business.Services
{
    public class PokemonService : IPokedexService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
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

            var registredPokemon = await _pokemonRepository.GetByName(pokemon.Name);

            if (registredPokemon != null)
            {
                // Notificar a inconsistência para o meu usuário
                return null;
            }

            await _pokemonRepository.AddAsync(pokemon);
            // Comitar a operação

            throw new NotImplementedException();
        }

        public Task DeletePokemonAsync(Guid pokemonId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePokemonAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}