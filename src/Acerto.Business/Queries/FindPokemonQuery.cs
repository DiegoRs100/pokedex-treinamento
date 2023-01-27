using Acerto.Business.Core.Pagination;

namespace Acerto.Business.Queries
{
    public class FindPokemonQuery : PagedInputModel
    {
        public string Name { get; set; } = default!;
        public Guid? CategoryId { get; set; }

        public bool HasName => !string.IsNullOrWhiteSpace(Name);
        public bool HasCategory => CategoryId != null;
    }
}