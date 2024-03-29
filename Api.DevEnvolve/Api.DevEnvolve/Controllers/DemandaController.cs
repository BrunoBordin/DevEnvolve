﻿using Api.DevEnvolve.Helper;
using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemandaController : ControllerBase
    {
        [HttpGet("GetDemandas")]
        public async Task<ActionResult<List<Demanda>>> GetDemandas()
        {
            return Ok(DemandaRepository.GetDemandas());
        }

        [HttpGet("GetDemandasEmpresa")]
        public async Task<ActionResult<List<DemandaEmpresa>>> GetDemandasEmpresa()
        {
            int id = User.Identity.GetPrestadorId();
            return Ok(DemandaRepository.GetDemandasEmpresa(id));
        }

        [HttpDelete("DeletarDemanda/{idDemanda}")]
        public async Task<IActionResult> DeletarDemanda(int idDemanda)
        {
            DemandaRepository.DeletarDemanda(User.Identity.GetPrestadorId(), idDemanda);
            return Ok();
        }

        [HttpGet("ConsultarCandidaturasDemanda")]
        public async Task<ActionResult<List<Candidatos>>> GetCandidaturas(int idDemanda)
        {
            List<Freelancer> cadidatos = DemandaRepository.ConsultarCandidaturasDemanda(idDemanda, User.Identity.GetPrestadorId());
            return Ok(cadidatos);
        }

        [HttpGet("GetNumeroCandidaturas")]
        public async Task<ActionResult<List<Candidatos>>> GetNumeroCandidaturas(int idDemanda)
        {
            List<Freelancer> cadidatos = DemandaRepository.ConsultarCandidaturasDemanda(idDemanda, User.Identity.GetPrestadorId());
            return Ok(cadidatos.Count);
        }

        [HttpGet("ConsultarDemandasCandidatado")]
        public async Task<ActionResult<List<DemandaCandidato>>> GetDemandasCandidatado()
        {
            List<DemandaCandidato> demandas = DemandaRepository.ConsultarDemandasCandidatado(User.Identity.GetPrestadorId());
            return Ok(demandas);
        }
    }
}