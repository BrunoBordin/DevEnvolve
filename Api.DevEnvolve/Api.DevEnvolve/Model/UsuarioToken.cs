namespace Api.DevEnvolve.Model
{
    public class UsuarioToken
    {
        public int? id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }
        public int idEndereco { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string token { get; set; }
    }

    public class UsuarioLogin
    {
        public string email { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
    }
}