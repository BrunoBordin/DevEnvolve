using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class Freelancer
    {
        [Key]
        public int? idFreelancer { get; set; }

        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public byte? foto { get; set; }
        public int? reputacao { get; set; }
        public string? descricao { get; set; }
    }
}