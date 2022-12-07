using Api.DevEnvolve.Helper;
using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize()]
    public class FreelancerController : ControllerBase
    {
        [HttpGet("Freelancers")]
        public async Task<ActionResult> GetFreelancers()
        {
            var freelancers = FreelancerRepository.GetFreelancers();
            return Ok(freelancers);
        }

        [HttpGet("PesquisaFreelancer")]
        public async Task<IActionResult> GetFreelancerByName(string nomeFreelancer)
        {
            var freelancer = FreelancerRepository.GetFreelancerByName(nomeFreelancer);
            if (freelancer == null)
            {
                return StatusCode(404, "Freelancer não encontrado. Verifique se o freelancer existe na base de dados");
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

        [HttpPatch("ReputacaoFreela/{idFreelancer}")]
        public async Task<IActionResult> Reputacao(int idFreelancer, int reputacao)
        {
            FreelancerRepository.Reputacao(reputacao, idFreelancer);
            return Ok();
        }

        [HttpPatch("SenhaFreela/{idFreelancer}")]
        public async Task<IActionResult> Senha(int idFreelancer, string senha)
        {
            int alteraSenha = FreelancerRepository.AlteraSenha(idFreelancer, senha);
            if (alteraSenha == 0)
            {
                return Ok();
            }
            else if (alteraSenha == 1)
            {
                return StatusCode(400, "Senha nova deve ser diferente da senha atual!");
            }
            else
            {
                return null;
            }
        }

        [HttpPatch("FotoPerfilFreela/{idFreelancer}")]
        public async Task<IActionResult> FotoPerfil(int idFreelancer, string foto)
        {
            FreelancerRepository.AlteraFotoPerfil(foto, idFreelancer);
            return Ok();
        }

        [HttpPost("CandidatarseDemanda")]
        public async Task<IActionResult> CandidatarSeDemanda(int idDemanda, int idEmpresa)
        {
            FreelancerRepository.CandidatarSeDemanda(User.Identity.GetPrestadorId(), idDemanda, idEmpresa);
            return Ok();
        }
    }
}