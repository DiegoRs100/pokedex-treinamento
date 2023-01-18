﻿using Acerto.Api.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Acerto.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public Startup(WebApplicationBuilder builder)
        {
            _configuration = builder.Configuration;
            _services = builder.Services;
        }

        public void ConfigureServices()
        {
            _services.AddControllers();
            _services.AddEndpointsApiExplorer();
            _services.AddSwaggerGen(options => options.EnableAnnotations());
            _services.AddAutoMapper(GetType().Assembly);
        }

        public void ConfigureApplication(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(options => options.MapControllers());
        }
    }
}