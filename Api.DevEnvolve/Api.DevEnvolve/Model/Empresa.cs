﻿using System.ComponentModel.DataAnnotations;

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

        public int idEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}