namespace Api.DevEnvolve.Model
{
    public class Usuario
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string descricao { get; set; }
        public string celular { get; set; }
        public string tipo { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public int idPlano { get; set; }
    }
}