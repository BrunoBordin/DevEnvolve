using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;
using static Api.DevEnvolve.Helper.Extension;

namespace Api.DevEnvolve.Repository
{
    public class EmpresaRepository
    {
        public static List<Empresa> GetEmpresas()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    return dbContext.Empresa.AsQueryable().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Empresa> GetEmpresaByName(string nomeEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var empresa = dbContext.Empresa.AsQueryable().Where(x => x.nome.Contains(nomeEmpresa)).ToList();

                    return empresa;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateEmpresa(Empresa empresa, int idEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Empresa empr = dbContext.Empresa.AsQueryable().Where(x => x.idEmpresa == idEmpresa).FirstOrDefault();

                    empr.nome = empresa.nome;
                    empr.email = empresa.email;

                    dbContext.Update(empr);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteEmpresa(int idEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Empresa? empresa = dbContext.Empresa.AsQueryable().Where(x => x.idEmpresa == idEmpresa).FirstOrDefault();

                    if (empresa != null)
                    {
                        dbContext.Remove(empresa);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int AlteraSenha(int idEmpresa, string senha)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Empresa? empresa = dbContext.Empresa.AsQueryable().Where(x => x.idEmpresa == idEmpresa).FirstOrDefault();

                    if (empresa != null)
                    {
                        var encod = new DefaultSGUPasswordEncoderHandler();
                        var senhaCripto = encod.encodePlainPassword(encod.plainPassword(empresa.email, senha));
                        if (senhaCripto != empresa.senha)
                        {
                            empresa.senha = senhaCripto;
                            dbContext.Update(empresa);
                            dbContext.SaveChanges();
                            return 0;
                        }
                        else return 1;
                    }
                    return 2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlteraFotoPerfil(string foto, int idFreelancer)
        {
            throw new NotImplementedException();
        }

        public static UsuarioToken GetEmpresaByLogin(string email, string senha)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var encod = new DefaultSGUPasswordEncoderHandler();
                    var senhaCripto = encod.encodePlainPassword(encod.plainPassword(email, senha));

                    Empresa? empresa = dbContext.Empresa.AsQueryable().Where(x => x.email == email && x.senha == senhaCripto).FirstOrDefault();
                    empresa.endereco = dbContext.EnderecoEmpresa.AsQueryable().Where(x => x.idEmpresa == empresa.idEmpresa).FirstOrDefault();
                    if (empresa != null)
                    {
                        UsuarioToken usuarioToken = new UsuarioToken()
                        {
                            id = empresa.idEmpresa,
                            nome = empresa.nome,
                            email = empresa.email,
                            senha = empresa.senha,
                            descricao = empresa.descricao
                        };
                        if (empresa.endereco != null)
                        {
                            usuarioToken.idEndereco = empresa.endereco.idEndereco;
                            usuarioToken.cidade = empresa.endereco.cidade;
                            usuarioToken.estado = empresa.endereco.estado;
                            usuarioToken.cep = empresa.endereco.cep;
                            usuarioToken.logradouro = empresa.endereco.logradouro;
                            usuarioToken.numero = empresa.endereco.numero;
                            usuarioToken.bairro = empresa.endereco.bairro;
                        }
                        return usuarioToken;
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Demanda CadastraDemanda(Demanda demanda, int id)
        {
            try
            {
                demanda.idEmpresa = id;
                using (var dbContext = new DataContext())
                {
                    var empresa = dbContext.Empresa.AsQueryable().Where(x => x.idEmpresa == id).FirstOrDefault();

                    demanda.nomeEmpresa = empresa.nome;
                    dbContext.Add(demanda);
                    dbContext.SaveChanges();
                    return dbContext.Demanda.AsQueryable().Where(z => z.idDemanda == demanda.idDemanda).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Freelancer> ConsultarCandidaturasDemanda(int idDemanda, int idEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var idFreelancers = dbContext.CandidatoDemanda.AsQueryable().Where(x => x.idEmpresa == idEmpresa && x.idDemanda == idDemanda && x.ativo == 0).ToList();
                    List<Freelancer> freelancers = new List<Freelancer>();
                    foreach (var id in idFreelancers)
                    {
                        freelancers.Add(dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == id.idFreelancer).FirstOrDefault());
                    }
                    return freelancers;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Demanda> GetDemandasEmpresa(int id)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    return dbContext.Demanda.AsQueryable().Where(x => x.idEmpresa == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Demanda> GetDemandas()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    return dbContext.Demanda.AsQueryable().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}