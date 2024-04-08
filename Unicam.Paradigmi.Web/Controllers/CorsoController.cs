using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Security.Claims;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Web.Utility;


namespace Unicam.Paradigmi.Web.Controllers
{
    //controller per la gestione dei corsi, necessita di autenticazione
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CorsoController : ControllerBase
    {

        private readonly ICorsoService _corsoService;


        public CorsoController(ICorsoService corsoService)
        {
            _corsoService = corsoService;
        }

        //endpoint per la creazione di un corso
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCorsoAsync(CreateCorsoRequest request)
        {
            var idUtente = IdentityUtility.GetUserIdentity(User.Identity as ClaimsIdentity);
            var corso = request.ToEntity();
            corso.IdDocente = idUtente;

            await _corsoService.AddCorsoAsync(corso);

            var response = new CreateCorsoResponse();
            response.Corso = new CorsoDto(corso);
            return Ok(ResponseFactory.WithSuccess(response));

        }

        //endpoint per l'eliminazione di un corso
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCorsoAsync(DeleteCorsoRequest request)
        {
            var idUtente = IdentityUtility.GetUserIdentity(User.Identity as ClaimsIdentity);
            var corso = await _corsoService.GetCorsoAsync(request.IdCorso);

            //controllo che l'utente che cerca di eseguire la cancellazione del corso sia lo stesso che lo ha creato
            if(idUtente.Equals(corso.IdDocente))
            {
                await _corsoService.DeleteAsync(corso);
                return Ok(ResponseFactory.WithSuccess("Corso cancellato"));
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Il corso da cancellare non è stato creato dall'utente loggato"));
            }
        }
        
    }
}
