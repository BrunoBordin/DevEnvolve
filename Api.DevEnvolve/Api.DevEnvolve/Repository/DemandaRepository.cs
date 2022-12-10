using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;

namespace Api.DevEnvolve.Repository
{
    public class DemandaRepository
    {
        public static List<Demanda> GetDemandaByName(string nomeDemanda)
        {
            try
            {
                using (var DbContext = new DataContext())
                {
                    List<Demanda> demandas = DbContext.Demanda.AsQueryable().Where(x => x.nome.Contains(nomeDemanda)).ToList();
                    return demandas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CandidatarSeDemanda(int idFreelancer, int idDemanda, int idEmpresa)
        {
            try
            {
                CandidatarDemanda candidatoDemanda = new CandidatarDemanda()
                {
                    idDemanda = idDemanda,
                    idFreelancer = idFreelancer,
                    idEmpresa = idEmpresa,
                    ativo = 0
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

        public static void CancelarCandidatura(int idDemanda, int idFreelancer)
        {
            using (var DbContext = new DataContext())
            {
                var demanda = DbContext.CandidatoDemanda.AsQueryable().Where(x => x.idDemanda == idDemanda && x.idFreelancer == idFreelancer).FirstOrDefault();
                demanda.ativo = 1;
                DbContext.Update(demanda);
                DbContext.SaveChanges();
            }
        }

        public static void DeletarDemanda(int v, int idDemanda)
        {
            try
            {
                using (var DbContext = new DataContext())
                {
                    var demanda = DbContext.Demanda.AsQueryable().Where(x => x.idDemanda == idDemanda).FirstOrDefault();
                    DbContext.Remove(demanda);
                    DbContext.SaveChanges();
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
    }
}