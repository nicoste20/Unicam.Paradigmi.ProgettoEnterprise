using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies()         //ottiene l'assembly della classe che contiene i validator
                .SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Paradigmi.Application")); 

            //aggiunge istanza del servizio
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICorsoService, CorsoService>();

            return services;
        }
    }
}
