using Acerto.Business.Entities;

namespace Acerto.Business.Repositories
{
    public interface IPokemonRepository
    {
        Task AddAsync(Pokemon pokemon);
        void Update(Pokemon pokemon);
        void Delete(Guid pokemonId);

        Task<bool> HasPokemonAsync(Guid pokemonId);
        Task<Pokemon?> GetByIdAsync(Guid pokemonId);
        Task<Pokemon> GetByNameAsync(string name);
        Task<IEnumerable<Pokemon>> FindAsync();
    }
}