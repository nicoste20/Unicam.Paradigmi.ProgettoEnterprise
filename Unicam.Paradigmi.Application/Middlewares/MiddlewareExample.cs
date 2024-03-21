using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;

namespace Unicam.Paradigmi.Application.Middlewares
{
    public class MiddlewareExample
    {
        //TODO:CONTROLLARE


        private RequestDelegate _next; //delegato della richiesta, lo invochiamo per passare al middleware successivo
        public MiddlewareExample(RequestDelegate next)
        { //costruttore
            _next = next;
        }

        //TODO:AGGIUNGERE COME IAZIENDA
        public async Task Invoke(HttpContext context,
            IUtenteService utenteService,
            IConfiguration configuration)
        {
            context.RequestServices.GetRequiredService<IUtenteService>();
            //codice effettivo del middleware

            //per andare al middleware successivo chiamare 
            await _next.Invoke(context);
        }
        
    }
}
