using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class CandidatoDemanda
    {
        [Key]
        public int idCandidatoDemanda { get; set; }

        public int idDemanda { get; set; }
        public int idFreelancer { get; set; }
        public int idEmpresa { get; set; }
    }
}