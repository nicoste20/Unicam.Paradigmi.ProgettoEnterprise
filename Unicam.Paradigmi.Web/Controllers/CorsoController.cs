using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Models;


namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class CorsoController :ControllerBase
    {


        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateCorso(CreateCorsoRequest request)
        {
            return Ok();
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCorso(DeleteCorsoRequest request)
        {
            return Ok();
        }
    }
}
