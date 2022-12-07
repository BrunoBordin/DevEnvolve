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
    public class EmpresaController : ControllerBase
    {
        [HttpGet("GetEmpresas")]
        public async Task<ActionResult> GetEmpresas()
        {
            return Ok(EmpresaRepository.GetEmpresas());
        }

        [HttpGet("PesquisaEmpresa")]
        public async Task<ActionResult<List<Empresa>>> GetEmpresaByName(string nomEmpresa)
        {
            List<Empresa> empresa = EmpresaRepository.GetEmpresaByName(nomEmpresa);
            if (empresa == null)
            {
                return StatusCode(404, "Empresa não encontrada. Verifique se a empresa existe na base de dados"); ;
            }
            return Ok(empresa);
        }

        [HttpGet("ConsultarCandidaturasDemanda")]
        public async Task<ActionResult<List<Candidatos>>> GetCandidaturas(int idDemanda)
        {
            List<Freelancer> cadidatos = EmpresaRepository.ConsultarCandidaturasDemanda(idDemanda, User.Identity.GetPrestadorId());
            return Ok(cadidatos);
        }

        [HttpPut("AtualizarEmpresa")]
        public async Task<IActionResult> UpdateEmpresa([FromBody] Empresa empresa)
        {
            EmpresaRepository.UpdateEmpresa(empresa, User.Identity.GetPrestadorId());
            return Ok();
        }

        [HttpDelete("DeletarEmpresa")]
        public async Task<IActionResult> DeletarEmpresa()
        {
            EmpresaRepository.DeleteEmpresa(User.Identity.GetPrestadorId());
            return Ok();
        }

        [HttpPatch("SenhaEmpresa")]
        public async Task<IActionResult> Senha(string senha)
        {
            int alteraSenha = EmpresaRepository.AlteraSenha(User.Identity.GetPrestadorId(), senha);
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

        [HttpPatch("FotoPerfilEmpresa")]
        public async Task<IActionResult> FotoPerfil(string foto)
        {
            EmpresaRepository.AlteraFotoPerfil(foto, User.Identity.GetPrestadorId());
            return Ok();
        }

        [HttpPost("CadastraDemanda")]
        public async Task<IActionResult> CadastraDemanda(Demanda demanda)
        {
            int id = User.Identity.GetPrestadorId();
            EmpresaRepository.CadastraDemanda(demanda, id);
            return Ok();
        }
    }
}