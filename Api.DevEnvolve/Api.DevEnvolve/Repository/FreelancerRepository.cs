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

        public static Freelancer GetFreelancerById(int idFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Freelancer freelancer = dbContext.Feelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).FirstOrDefault();

                    return freelancer;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}