using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class Empresa
    {
        [Key]
        public int? idEmpresa { get; set; }

        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
    }
}