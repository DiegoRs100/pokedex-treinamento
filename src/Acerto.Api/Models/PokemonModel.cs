using Acerto.Business.Enums;

namespace Acerto.Api.Models
{
    public class PokemonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public Gender Gender { get; set; }

        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
    }
}