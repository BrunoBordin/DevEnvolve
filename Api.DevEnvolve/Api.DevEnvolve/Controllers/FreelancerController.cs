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

        [HttpGet("SkillsFreelancers")]
        public async Task<ActionResult> GetSkillsFreelancers()
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            var Skillsfreelancers = SkillsRepository.GetSkillsFreelancers(idFreelancer);
            return Ok(Skillsfreelancers);
        }

        [HttpGet("PesquisaDemanda")]
        public async Task<ActionResult<List<Demanda>>> GetDemandaByName(string nomeDemanda)
        {
            List<Demanda> demandas = DemandaRepository.GetDemandaByName(nomeDemanda);
            if (demandas == null || demandas.Count() == 0)
            {
                return StatusCode(404, "Demanda não encontrada!");
            }
            return Ok(demandas);
        }

        [HttpGet("PesquisaFreelancer")]
        public async Task<ActionResult<List<Freelancer>>> GetFreelancerByName(string nomeFreelancer)
        {
            var freelancer = FreelancerRepository.GetFreelancerByName(nomeFreelancer);
            if (freelancer == null)
            {
                return StatusCode(404, "Freelancer não encontrado. Verifique se o freelancer existe na base de dados");
            }
            return Ok(freelancer);
        }

        [HttpPut("AtualizarFreelancer")]
        public async Task<IActionResult> UpdateFreelancer([FromBody] Freelancer freelancer)
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            FreelancerRepository.UpdateFreelancer(freelancer, idFreelancer);
            return Ok();
        }

        [HttpDelete("DeletarFreelancer")]
        public async Task<IActionResult> DeletarFreelancer()
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            FreelancerRepository.DeleteFreelancer(idFreelancer);
            return Ok();
        }

        [HttpPatch("ReputacaoFreela")]
        public async Task<IActionResult> Reputacao(int reputacao)
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            FreelancerRepository.Reputacao(reputacao, idFreelancer);
            return Ok();
        }

        [HttpPatch("SenhaFreela")]
        public async Task<IActionResult> Senha(string senha)
        {
            int idFreelancer = User.Identity.GetPrestadorId();
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

        [HttpPatch("FotoPerfilFreela")]
        public async Task<IActionResult> FotoPerfil(string foto)
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            FreelancerRepository.AlteraFotoPerfil(foto, idFreelancer);
            return Ok();
        }

        [HttpPost("CandidatarseDemanda")]
        public async Task<IActionResult> CandidatarSeDemanda(int idDemanda, int idEmpresa)
        {
            DemandaRepository.CandidatarSeDemanda(User.Identity.GetPrestadorId(), idDemanda, idEmpresa);
            return Ok();
        }

        [HttpPatch("CancelarCandidatura")]
        public async Task<IActionResult> CancelarCandidatura(int idDemanda)
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            DemandaRepository.CancelarCandidatura(idDemanda, idFreelancer);
            return Ok();
        }
    }
}