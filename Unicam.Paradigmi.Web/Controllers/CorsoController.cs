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
    public class CorsoController :ControllerBase
    {

        private readonly ICorsoService _corsoService;

        public CorsoController(ICorsoService corsoService)
        {
            _corsoService = corsoService;
        }

        [Authorize(Roles = "Docente")]
        [HttpPost]
        [Route("new")]
        public IActionResult CreateCorso(CreateCorsoRequest request)
        {
            var corso = request.ToEntity();
            _corsoService.AddCorso(corso);
            var response = new CreateCorsoResponse();
            response.Corso = new CorsoDto(corso);
            return Ok(ResponseFactory.WithSuccess(response));
        }


        /*
        
        [Authorize(Roles = "Docente")]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCorso(DeleteCorsoRequest request)
        {
            return Ok();
        }


        [Authorize(Roles = "Studente")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NomeMetodo(CreateCorsoRequest request)
        {
            return Ok();
        }
        */
    }
}
