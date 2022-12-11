namespace Api.DevEnvolve.Model
{
    public class DemandaCandidato
    {
        public int idDemanda { get; set; }
        public string nome { get; set; }
        public int stack { get; set; }
        public decimal valor { get; set; }
        public string dataCandidatura { get; set; }
        public string descricao { get; set; }
    }
}
