using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
    public class CorsoController : ControllerBase
    {

        private readonly ICorsoService _corsoService;

        private readonly IIdentityService _identityService;

        public CorsoController(ICorsoService corsoService, IIdentityService identityService)
        {
            _corsoService = corsoService;
            _identityService = identityService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateCorso(CreateCorsoRequest request)
        {
            int idUtente = _identityService.GetUserIdentity();
            var corso = request.ToEntity();
            corso.IdDocente = idUtente;
            //aggiungere il corso.Docente
            _corsoService.AddCorso(corso);
            var response = new CreateCorsoResponse();
            response.Corso = new CorsoDto(corso);
            return Ok(ResponseFactory.WithSuccess(response));
        }


        
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteCorso(DeleteCorsoRequest request)
        {
            _corsoService.Delete(request.IdCorso);
            return Ok(ResponseFactory.WithSuccess(Response));
        }
        
    }
}
