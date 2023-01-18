using Acerto.Api.Models;
using Acerto.Business.Entities;
using AutoMapper;

namespace Acerto.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PokemonModel, Pokemon>().ReverseMap();
        }
    }
}