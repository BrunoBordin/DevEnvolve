using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class Skills
    {
        [Key]
        public int idSkill { get; set; }
        public string descricao { get; set; }
    }
}