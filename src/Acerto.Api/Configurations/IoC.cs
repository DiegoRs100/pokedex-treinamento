using Acerto.Business.Repositories;
using Acerto.Business.Services;
using Acerto.Infra.Repositories;

namespace Acerto.Api.Configurations
{
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPokedexService, PokedexService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPokemonRepository, PokemonRepository>();
            return services;
        }
    }
}