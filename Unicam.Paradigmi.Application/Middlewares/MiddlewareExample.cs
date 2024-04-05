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
            ICorsoService corsoService,
            IConfiguration configuration)
        {
            context.RequestServices.GetRequiredService<IUtenteService>();
            //codice effettivo del middleware

            //per andare al middleware successivo chiamare 
            await _next.Invoke(context);
        }
        
    }
}
