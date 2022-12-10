using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;

namespace Api.DevEnvolve.Repository
{
    public class PlanosRepository
    {
        public static List<PlanosDevEnvolve> GetPlanosEmpresa()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    return dbContext.PlanosDevEnvolve.AsQueryable().Where(x => x.usuario == 1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PlanosDevEnvolve> GetPlanosFreelancer()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    return dbContext.PlanosDevEnvolve.AsQueryable().Where(x => x.usuario == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}