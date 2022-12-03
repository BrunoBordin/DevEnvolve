using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}