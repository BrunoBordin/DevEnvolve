using System.ComponentModel.DataAnnotations;

namespace Api.DevEnvolve.Model
{
    public class CandidatarDemanda
    {
        [Key]
        public int idCandidatoDemanda { get; set; }

        public int idDemanda { get; set; }
        public int idFreelancer { get; set; }
        public int idEmpresa { get; set; }
    }

    public class Candidatos
    {
        public List<Freelancer> Freelancers { get; set; }
    }
}