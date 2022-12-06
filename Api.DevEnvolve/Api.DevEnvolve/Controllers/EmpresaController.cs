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
        public async Task<IActionResult> GetEmpresaByName(string nomEmpresa)
        {
            var empresa = EmpresaRepository.GetEmpresaByName(nomEmpresa);
            if (empresa == null)
            {
                return StatusCode(404, "Empresa não encontrada. Verifique se a empresa existe na base de dados"); ;
            }
            return Ok(empresa);
        }

        [HttpPut("AtualizarEmpresa/{idEmpresa}")]
        public async Task<IActionResult> UpdateEmpresa([FromBody] Empresa empresa, int idEmpresa)
        {
            EmpresaRepository.UpdateEmpresa(empresa, idEmpresa);
            return Ok();
        }

        [HttpDelete("DeletarEmpresa/{idEmpresa}")]
        public async Task<IActionResult> DeletarEmpresa(int idEmpresa)
        {
            EmpresaRepository.DeleteEmpresa(idEmpresa);
            return Ok();
        }

        [HttpPatch("SenhaEmpresa/{idEmpresa}")]
        public async Task<IActionResult> Senha(int idEmpresa, string senha)
        {
            int alteraSenha = EmpresaRepository.AlteraSenha(idEmpresa, senha);
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

        [HttpPatch("FotoPerfilEmpresa/{idEmpresa}")]
        public async Task<IActionResult> FotoPerfil(int idEmpresa, string foto)
        {
            EmpresaRepository.AlteraFotoPerfil(foto, idEmpresa);
            return Ok();
        }

        [HttpPost("CadastraDemanda")]
        public async Task<IActionResult> CadastraDemanda()
        {
            var id = User.Identity.GetPrestadorId();
            return Ok();
        }
    }
}