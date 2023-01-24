using Acerto.Business.Entities;
using Acerto.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Acerto.Infra.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly EFDbContext _efContext;

        public PokemonRepository(EFDbContext efContext)
        {
            _efContext = efContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _efContext.Pokemons.AddAsync(pokemon);
        }

        public void Delete(Guid pokemonId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pokemon>> FindAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pokemon?> GetByIdAsync(Guid pokemonId)
        {
            return _efContext.Pokemons
                .FirstOrDefaultAsync(p => p.Id == pokemonId);
        }

        public Task<Pokemon> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPokemonAsync(Guid pokemonId)
        {
            throw new NotImplementedException();
        }

        public void Update(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}