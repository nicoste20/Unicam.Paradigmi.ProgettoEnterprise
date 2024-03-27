using FluentValidation;
using Microsoft.AspNetCore.Http;
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

            //Istanze del servizio
            //Permette di accedere alle contesto di chiamate e risposte HTTP
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICorsoService, CorsoService>();
            services.AddScoped<ILezioneService, LezioneService>();

            return services;
        }
    }
}
