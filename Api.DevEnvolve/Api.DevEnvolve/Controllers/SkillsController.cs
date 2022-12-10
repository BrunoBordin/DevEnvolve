using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.DevEnvolve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        [HttpGet("getSkills")]
        public async Task<ActionResult> GetSkills()
        {
            var skills = SkillsRepository.GetSkills();
            return Ok(skills);
        }
    }
}