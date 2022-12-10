using Api.DevEnvolve.Helper;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        [HttpGet("GetSkills")]
        public async Task<ActionResult> GetSkills()
        {
            var skills = SkillsRepository.GetSkills();
            return Ok(skills);
        }

        [HttpPost("PostSkillsFreelancer")]
        public async Task<ActionResult<List<int>>> PostSkillsFreelancer(List<int> idSkill)
        {
            int idFreelancer = User.Identity.GetPrestadorId();
            SkillsRepository.PostSkillsFreelancer(idSkill, idFreelancer);
            return Ok();
        }
    }
}