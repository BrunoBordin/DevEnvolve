using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class Skills
    {
        [Key]
        public int idSkillsFreelancer { get; set; }
        public int idSkill { get; set; }
        public int idFreelancer { get; set; }
    }
}