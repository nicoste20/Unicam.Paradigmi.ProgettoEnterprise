using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    //controller per la gestione degli utenti, necessita di autorizzazione
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        //endpoint per la creazione di un utente 
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateUtenteAsync(CreateUtenteRequest request) {
            //gestione errore se utente già presente
            if(await _utenteService.GetUserByEmailAsync(request.Email) != null)
            {
                return BadRequest(ResponseFactory.WithError("Utente non aggiunto, email già presente nel sistema"));
            }

            var utente = request.ToEntity();
            await _utenteService.AddUtenteAsync(utente);

            var response = new CreateUtenteResponse();
            response.utente = new UtenteDto(utente);
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
