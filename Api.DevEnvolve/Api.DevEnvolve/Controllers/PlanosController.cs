using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanosController : ControllerBase
    {
        [HttpGet("GetPlanosEmpresa")]
        public async Task<ActionResult<PlanosDevEnvolve>> GetPlanosEmpresa()
        {
            return Ok(PlanosRepository.GetPlanosEmpresa());
        }

        [HttpGet("GetPlanosFreelancer")]
        public async Task<ActionResult<PlanosDevEnvolve>> GetPlanosFreelancer()
        {
            return Ok(PlanosRepository.GetPlanosFreelancer());
        }
    }
}