using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    //controller per la gestione dei token JWT
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {

        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        //endpoint per la creazione del token JWT a partire dalle credenziali fornite
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest request)
        {
            string token = await _tokenService.CreateTokenAsync(request.Email,request.Password);

            if (token != null)
            {
                return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
            }
            return BadRequest(ResponseFactory.WithError("Email o Password errata"));
        }
        
    }
}
