using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;
using static Api.DevEnvolve.Helper.Extension;

namespace Api.DevEnvolve.Repository
{
    public class FreelancerRepository
    {
        public static List<Freelancer> GetFreelancers()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    List<Freelancer> freelancers = dbContext.Feelancer.AsQueryable().ToList();

                    return freelancers;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Freelancer GetFreelancerByName(string nomeFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var freelancer = dbContext.Feelancer.AsQueryable().Where(x => x.nome.Contains(nomeFreelancer)).FirstOrDefault();

                    return freelancer;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UsuarioToken GetFreelancerByLogin(string email, string senha)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var encod = new DefaultSGUPasswordEncoderHandler();
                    var senhaCripto = encod.encodePlainPassword(encod.plainPassword(email, senha));

                    Freelancer? freelancer = dbContext.Feelancer.AsQueryable().Where(x => x.email == email && x.senha == senhaCripto).FirstOrDefault();
                    if (freelancer != null)
                    {
                        UsuarioToken usuarioToken = new()
                        {
                            id = freelancer.idFreelancer,
                            email = freelancer.email,
                            senha = freelancer.senha
                        };
                        return usuarioToken;
                    }
                    else return null;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateFreelancer(Freelancer freelancer, int idFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Freelancer freeler = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();

                    freeler.nome = freelancer.nome;
                    freeler.email = freelancer.email;

                    dbContext.Update(freeler);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFreelancer(int idFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Freelancer? freeler = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();
                    if (freeler != null)
                    {
                        dbContext.Remove(freeler);
                        EnderecoFreelancer endereco = dbContext.EnderecoFreelancer.AsQueryable().Where(x => x.idFreelancer == freeler.idFreelancer).FirstOrDefault();
                        dbContext.Remove(endereco);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Reputacao(int reputacao, int idFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Freelancer? freeler = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();
                    if (freeler!= null)
                    {
                        freeler.reputacao= reputacao;
                        dbContext.Update(freeler);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int AlteraSenha(int idFreelancer, string senha)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Freelancer? freelancer = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();

                    if (freelancer != null)
                    {
                        var encod = new DefaultSGUPasswordEncoderHandler();
                        var senhaCripto = encod.encodePlainPassword(encod.plainPassword(freelancer.email, senha));
                        if (senhaCripto != freelancer.senha)
                        {
                            freelancer.senha = senhaCripto;
                            dbContext.Update(freelancer);
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

        public static void CandidatarSeDemanda(int idFreelancer, int idDemanda, int idEmpresa)
        {
            try
            {
                CandidatarDemanda candidatoDemanda = new CandidatarDemanda()
                {
                    idDemanda = idDemanda,
                    idFreelancer = idFreelancer,
                    idEmpresa = idEmpresa
                };
                using (var DbContext = new DataContext())
                {
                    DbContext.Add(candidatoDemanda);
                    DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}