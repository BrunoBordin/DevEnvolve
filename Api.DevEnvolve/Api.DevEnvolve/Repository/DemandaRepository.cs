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
    }
}