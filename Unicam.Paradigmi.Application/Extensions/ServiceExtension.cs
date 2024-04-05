using FluentValidation;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Paradigmi.Application"));

            
            services.AddScoped<IEmailService, EmailService>();
            //Permette di accedere alle contesto di chiamate e risposte HTTP
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICorsoService, CorsoService>();
            services.AddScoped<ILezioneService, LezioneService>();
            services.AddScoped<IPresenzaService, PresenzaService>();

            return services;
        }
    }
}
