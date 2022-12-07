using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class PlanosDevEnvolve
    {
        [Key]
        public int idPlano { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public char usuario { get; set; }
    }
}