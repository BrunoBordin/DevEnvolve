using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("AddUsuario")]
        public async Task<IActionResult> AddUsuario([FromBody] Usuario usuario)
        {
            UsuarioRepository.AddUsuario(usuario);
            return Ok(usuario);
        }
    }
}