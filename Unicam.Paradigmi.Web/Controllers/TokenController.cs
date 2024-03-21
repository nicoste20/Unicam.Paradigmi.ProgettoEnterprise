using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using System.Data;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

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
            if (!string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Password)) {
                // Controlla la richiesta con gli utenti presenti nella piattaforma
                var isValidRequest = ValidaRichiesta(request);

                if (!isValidRequest)
                {
                    return BadRequest("Richiesta non valida");
                }

                string token = _tokenService.CreateToken(request);
                /*
                return Ok(
                   ResponseFactory.WithSuccess(
                       new CreateTokenResponse(token)
                       )
                   );
                */

                // Step 1: Verifica il ruolo dell'utente
                var user = _utenteService.GetUserByEmail(request.Email);
                //var userRole = user.Role;
                var userRole = "Docente";

                if (userRole == "Docente")
                {
                    // Esegui le operazioni per i docenti
                    return Ok(new { token, role = "Docente" });
                }
                else if (userRole == "Alunno")
                {
                    // Esegui le operazioni per gli studenti
                    return Ok(new { token, role = "Alunno" });
                }
                else
                {
                    return BadRequest("Ruolo non valido");
                }
            }
            return BadRequest("Credenziali in input vuote");
        }
    

        private bool ValidaRichiesta(CreateTokenRequest request)
        {
            // Cerca l'utente nel database utilizzando l'email fornita nella richiesta
            var user = _utenteService.GetUserByEmail(request.Email);

            // Se non viene trovato nessun utente con quella email, la richiesta non è valida
            if (user == null)
            {
                return false;
            }

            // Verifica se la password fornita nella richiesta corrisponde alla password dell'utente nel database
            bool isPasswordValid = _utenteService.VerifyPassword(user, request.Password);

            // Restituisci true se l'email e la password sono valide, altrimenti false
            return isPasswordValid;

        }
    }
}
