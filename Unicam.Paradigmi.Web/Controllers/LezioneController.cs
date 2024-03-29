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

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateLezioneAsync(CreateLezioneRequest request)
        {
            if (await _corsoService.GetCorsoAsync(request.IdCorso) !=null)
            {
                var lezione = request.ToEntity();
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
