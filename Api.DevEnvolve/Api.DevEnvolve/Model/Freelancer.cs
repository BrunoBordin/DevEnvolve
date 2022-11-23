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
        public string telefone { get; set; }
        public string celular { get; set; }
        public string cpfCnpj { get; set; }
        public int cidade { get; set; }
        public string estado { get; set; }
        public string sobre { get; set; }
        public decimal saldo { get; set; }
    }
}