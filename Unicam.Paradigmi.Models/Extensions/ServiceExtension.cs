using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MyDbContext>(conf => {
                //prende la stringa di connessione dal json
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<UtenteRepository>();
            services.AddScoped<CorsoRepository>();
            services.AddScoped<LezioneRepository>();
            services.AddScoped<PresenzaRepository>();
            return services;
        }
    }
}
