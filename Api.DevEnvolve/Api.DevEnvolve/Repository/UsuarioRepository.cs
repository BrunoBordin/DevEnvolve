﻿using Api.DevEnvolve.Data;
using Api.DevEnvolve.Helper;
using Api.DevEnvolve.Model;
using static Api.DevEnvolve.Helper.Extension;

namespace Api.DevEnvolve.Repository
{
    public class UsuarioRepository
    {
        public static void AddUsuario(Usuario usuario)
        {
            try
            {
                if (usuario.tipo.ToLower().Trim().Contains("freela"))
                {
                    var encod = new DefaultSGUPasswordEncoderHandler();
                    var senhaCripto = encod.encodePlainPassword(encod.plainPassword(usuario.email, usuario.senha));

                    Freelancer userFreelancer = new Freelancer
                    {
                        nome = usuario.nome,
                        email = usuario.email,
                        senha = senhaCripto,
                        celular = Extension.RemoveNonNumeric(usuario.celular),
                        descricao = usuario.descricao
                    };
                    using (var dbContext = new DataContext())
                    {
                        dbContext.Feelancer.Add(userFreelancer);
                        dbContext.SaveChanges();
                    }
                    EnderecoFreelancer enderecoFreelancer = new EnderecoFreelancer()
                    {
                        idFreelancer = userFreelancer.idFreelancer,
                        cidade = usuario.cidade,
                        estado = usuario.estado,
                        cep = usuario.cep,
                        logradouro = usuario.logradouro,
                        numero = usuario.numero,
                        bairro= usuario.bairro,
                    };
                    using (var dbContext = new DataContext())
                    {
                        dbContext.EnderecoFreelancer.Add(enderecoFreelancer);
                        dbContext.SaveChanges();
                    }
                    PlanoFreelancer planoFreelancer = new PlanoFreelancer()
                    {
                        idFreelancer = userFreelancer.idFreelancer,
                        idPlano = usuario.idPlano
                    };
                    using (var dbContext = new DataContext())
                    {
                        dbContext.PlanoFreelancer.Add(planoFreelancer);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    var encod = new DefaultSGUPasswordEncoderHandler();
                    var senhaCripto = encod.encodePlainPassword(encod.plainPassword(usuario.email, usuario.senha));

                    Empresa userEmpresa = new Empresa
                    {
                        nome = usuario.nome,
                        email = usuario.email,
                        senha = senhaCripto,
                        celular = Extension.RemoveNonNumeric(usuario.celular),
                        descricao = usuario.descricao
                    };
                    using (var dbContext = new DataContext())
                    {
                        dbContext.Empresa.Add(userEmpresa);
                        dbContext.SaveChanges();
                    }
                    EnderecoEmpresa enderecoEmpresa = new EnderecoEmpresa()
                    {
                        idEmpresa = userEmpresa.idEmpresa,
                        cidade = usuario.cidade,
                        estado = usuario.estado,
                        cep = usuario.cep,
                        logradouro = usuario.logradouro,
                        numero = usuario.numero,
                        bairro= usuario.bairro,
                    };
                    using (var dbContext = new DataContext())
                    {
                        dbContext.EnderecoEmpresa.Add(enderecoEmpresa);
                        dbContext.SaveChanges();
                    }
                    PlanoEmpresa planoEmpresa = new PlanoEmpresa()
                    {
                        idEmpresa = userEmpresa.idEmpresa,
                        idPlano = usuario.idPlano
                    };
                    using (var dbContext = new DataContext())
                    {
                        dbContext.PlanoEmpresa.Add(planoEmpresa);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}