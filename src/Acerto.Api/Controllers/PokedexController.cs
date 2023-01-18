using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Acerto.Business.Entities;
using Acerto.Business.Services;
using Acerto.Api.Models;
using AutoMapper;

namespace Acerto.Api.Controllers
{
    [Route("pokedex")]
    public class PokedexController : ControllerBase
    {
        private readonly IPokedexService _pokedexService;
        private readonly IMapper _mapper;

        public PokedexController(IPokedexService pokedexService, IMapper mapper)
        {
            _pokedexService = pokedexService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation("Cadastrar pokémon.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddPokemon([FromBody] PokemonModel model)
        {
            var pokemon = _mapper.Map<Pokemon>(model);
            var pokemonById = await _pokedexService.AddPokemon(pokemon);

            return Created($"{HttpContext.Request.Path}/{pokemonById}", null);
        }
         
        [HttpPut]
        [SwaggerOperation("Atualizar cadastro de pokémon.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePokemon([FromBody] PokemonModel model)
        {
            var pokemon = _mapper.Map<Pokemon>(model);
            await _pokedexService.UpdatePokemon(pokemon);

            return NoContent();
        }

        [HttpDelete("{pokemonId:guid}")] // http:acerto/pokedex/guyufi-fsdf-fsdf-fsdfsd
        [SwaggerOperation("Remover pokémon.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePokemon(Guid pokemonId)
        {
            await _pokedexService.DeletePokemon(pokemonId);
            return NoContent();
        }

        [HttpGet("{pokemonId:guid}")]
        [SwaggerOperation("Obter pokémon por Id.")]
        [ProducesResponseType(typeof(Pokemon), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPokemonById(Guid pokemonId)
        {
            return Ok(new Pokemon("", Guid.NewGuid(), Business.Enums.Gender.All, 1, 1, 1, 1));
        }

        [HttpGet("find")]
        [SwaggerOperation("Listar pokémons.")]
        [ProducesResponseType(typeof(IEnumerable<Pokemon>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindPokemon()
        {
            return Ok();
        }
    }
}