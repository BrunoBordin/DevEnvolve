using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class EnderecoEmpresa
    {
        [Key]
        public int idEndereco { get; set; }
        public int idEmpresa { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
    }
}