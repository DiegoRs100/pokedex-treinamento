using Acerto.Infra;
using Microsoft.EntityFrameworkCore;

namespace Acerto.Api.Configurations
{
    public static class DbContextsConfig
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["SqlServer:PokedexDb"];

            services.AddDbContext<EFDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(4, TimeSpan.FromSeconds(20), null);
                });
            });

            return services;
        }
    }
}