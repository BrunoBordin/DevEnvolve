using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;

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
                    Freelancer freeler = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();
                    dbContext.Remove(freeler);
                    EnderecoFreelancer endereco = dbContext.EnderecoFreelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();
                    if (endereco != null)
                        dbContext.Remove(endereco);
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