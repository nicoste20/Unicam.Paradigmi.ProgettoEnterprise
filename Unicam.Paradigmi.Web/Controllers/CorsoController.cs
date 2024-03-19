using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Models.Requests;


namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CorsoController :ControllerBase
    {

        [Authorize(Roles = "Docente")]
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCorso(CreateCorsoRequest request)
        {
            return Ok();
        }

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

    }
}
