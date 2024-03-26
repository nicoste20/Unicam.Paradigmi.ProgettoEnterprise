using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Data;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {

        //TODO:IMPLEMENTARE GLI UTENTI 
        private readonly ITokenService _tokenService;

        private readonly IUtenteService _utenteService;


        public TokenController(ITokenService tokenService, IUtenteService userService)
        {
            _tokenService = tokenService;
            _utenteService = userService;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateTokenRequest request)
        {
            string token = _tokenService.CreateToken(request);

            return Ok(
               ResponseFactory.WithSuccess(
                   new CreateTokenResponse(token)
                   )
            );
        }
    

        
    }
}
