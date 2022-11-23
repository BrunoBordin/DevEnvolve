using Api.DevEnvolve.Data;
using Api.DevEnvolve.Helper;
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

        public static Freelancer GetFreelancerById(int idFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var freelancer = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();

                    return freelancer;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddFreelancer(Freelancer freelancer)
        {
            try
            {
                var encod = new DefaultSGUPasswordEncoderHandler();

                var senhaCripto = encod.encodePlainPassword(encod.plainPassword(freelancer.email, freelancer.senha));

                Freelancer freela = new Freelancer
                {
                    nome = freelancer.nome,
                    email = freelancer.email,
                    senha = senhaCripto,
                    telefone = freelancer.telefone,
                    celular = Extension.RemoveNonNumeric(freelancer.celular),
                    cpfCnpj = Extension.RemoveNonNumeric(freelancer.cpfCnpj),
                    cidade = freelancer.cidade,
                    estado = freelancer.estado.ToUpper(),
                    sobre = freelancer.sobre,
                    saldo = 0,
                };
                using (var dbContext = new DataContext())
                {
                    dbContext.Feelancer.Add(freela);
                    dbContext.SaveChanges();
                }
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
                    freeler.telefone = freelancer.telefone;
                    freeler.celular = freelancer.celular;
                    freeler.cidade = freelancer.cidade;
                    freeler.estado = freelancer.estado;
                    freeler.sobre = freelancer.sobre;

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
                    Freelancer freeler = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();
                    dbContext.Remove(freeler);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}