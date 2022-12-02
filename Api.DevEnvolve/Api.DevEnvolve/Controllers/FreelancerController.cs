using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreelancerController : ControllerBase
    {
        [HttpGet("Freelancers")]
        public async Task<ActionResult> GetFreelancers()
        {
            var freelancers = FreelancerRepository.GetFreelancers();
            return Ok(freelancers);
        }

        [HttpGet("Freelancer/{idFreelancer}")]
        public async Task<IActionResult> GetFreelancerById(int idFreelancer)
        {
            var freelancer = FreelancerRepository.GetFreelancerById(idFreelancer);
            if (freelancer == null)
            {
                return StatusCode(404, "Freelancer não encontrado. Verifique se o freelancer existe na base de dados"); ;
            }
            return Ok(freelancer);
        }

        [HttpPut("AtualizarFreelancer/{idFreelancer}")]
        public async Task<IActionResult> UpdateFreelancer([FromBody] Freelancer freelancer, int idFreelancer)
        {
            FreelancerRepository.UpdateFreelancer(freelancer, idFreelancer);
            return Ok();
        }

        [HttpDelete("DeletarFreelancer/{idFreelancer}")]
        public async Task<IActionResult> DeletarFreelancer(int idFreelancer)
        {
            FreelancerRepository.DeleteFreelancer(idFreelancer);
            return Ok();
        }
    }
}