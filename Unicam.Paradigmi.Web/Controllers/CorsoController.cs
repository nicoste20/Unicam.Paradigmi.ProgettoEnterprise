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
        public async Task<IActionResult> CreateCorsoAsync(CreateCorsoRequest request)
        {
            int idUtente = _identityService.GetUserIdentity();
            var corso = request.ToEntity();
            corso.IdDocente = idUtente;
            await _corsoService.AddCorsoAsync(corso);
            var response = new CreateCorsoResponse();
            response.Corso = new CorsoDto(corso);
            return Ok(ResponseFactory.WithSuccess(response));
        }


        
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCorsoAsync(DeleteCorsoRequest request)
        {
            await _corsoService.DeleteAsync(request.IdCorso);
            return Ok(ResponseFactory.WithSuccess(Response));
        }
        
    }
}
