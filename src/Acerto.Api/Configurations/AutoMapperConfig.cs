using Acerto.Api.Models;
using Acerto.Business.Core.Pagination;
using Acerto.Business.Entities;
using AutoMapper;

namespace Acerto.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PokemonModel, Pokemon>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
        }
    }
}