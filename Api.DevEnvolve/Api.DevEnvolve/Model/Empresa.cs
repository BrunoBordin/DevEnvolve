using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }

        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public string? foto { get; set; }
        public int? reputacao { get; set; }
        public string? descricao { get; set; }
        public EnderecoEmpresa endereco { get; set; }
        public PlanoEmpresa planoEmpresa { get; set; }
    }

    public class EnderecoEmpresa
    {
        [Key]
        public int idEndereco { get; set; }

        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }

        public int idEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }

    public class Demanda
    {
        [Key]
        public int idDemanda { get; set; }

        public int idEmpresa { get; set; }
        public string nome { get; set; }
        public int stack { get; set; }
        public decimal preco { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string? nomeEmpresa { get; set; }
    }
    public class DemandaEmpresa
    {
        [Key]
        public int idDemanda { get; set; }

        public int idEmpresa { get; set; }
        public string nome { get; set; }
        public int stack { get; set; }
        public decimal preco { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string? nomeEmpresa { get; set; }
        public int numeroCandidatos { get; set; }
    }

    public class PlanoEmpresa
    {
        [Key]
        public int idPlanoEmpresa { get; set; }

        public int idEmpresa { get; set; }
        public int idPlano { get; set; }
        public Empresa Empresa { get; set; }
    }
}