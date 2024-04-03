using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Dtos;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    //controller per la gestione delle lezioni, necessita di autorizzazione
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LezioneController : ControllerBase
    {
        private readonly ICorsoService _corsoService;

        private readonly ILezioneService _lezioneService;

        public LezioneController(ICorsoService corsoService, ILezioneService lezioneService)
        {
            _corsoService = corsoService;
            _lezioneService = lezioneService;
        }


        //endpoint per la creazione di una nuova lezione 
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateLezioneAsync(CreateLezioneRequest request)
        {
            //controllo che il corso per cui si sta inserendo una lezione esista
            if (await _corsoService.GetCorsoAsync(request.IdCorso) !=null)
            {
                var lezione = request.ToEntity();

                //gestione errore se la lezione risulta nulla
                if (lezione == null)
                {
                    return BadRequest(ResponseFactory.WithError("Lezione nulla"));
                }

                await _lezioneService.AddLezioneAsync(lezione);

                var response = new CreateLezioneResponse();
                response.Lezione = new LezioneDto(lezione);
                return Ok(ResponseFactory.WithSuccess(response));
            }
            else
            {
                return BadRequest("Corso non trovato");
            }
        }
    }
}
