using Acerto.Business.Entities;

namespace Acerto.Business.Services
{
    public interface IPokedexService
    {
        Task<Guid?> AddPokemon(Pokemon pokemon);
        Task UpdatePokemon(Pokemon pokemon);
        Task DeletePokemon(Guid pokemonId);
    }
}