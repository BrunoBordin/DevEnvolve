using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class Freelancer
    {
        [Key]
        public int idFreelancer { get; set; }

        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public byte? foto { get; set; }
        public int? reputacao { get; set; }
        public string? descricao { get; set; }
        public decimal? saldo { get; set; }
        public EnderecoFreelancer endereco { get; set; }
    }

    public class EnderecoFreelancer
    {
        [Key]
        public int idEndereco { get; set; }

        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public int idFreelancer { get; set; }
        public Freelancer freelancer { get; set; }
    }
}