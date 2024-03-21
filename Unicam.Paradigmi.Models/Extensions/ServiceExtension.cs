using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MyDbContext>(conf => {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")); //prende la stringa di connessione dal json
            }); //aggiunta del db

            services.AddScoped<UtenteRepository>();
            return services;
        }
    }
}
