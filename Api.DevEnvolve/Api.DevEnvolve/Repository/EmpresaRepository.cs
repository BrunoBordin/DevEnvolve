using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;

namespace Api.DevEnvolve.Repository
{
    public class EmpresaRepository
    {
        public static List<Empresa> GetFreelancers()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    List<Empresa> empresas = dbContext.Empresa.AsQueryable().ToList();

                    return empresas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Empresa GetFreelancerByName(string nomeEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var empresa = dbContext.Empresa.AsQueryable().Where(x => x.nome.Contains(nomeEmpresa)).FirstOrDefault();

                    return empresa;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateFreelancer(Empresa empresa, int idEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Empresa freeler = dbContext.Empresa.AsQueryable().Where(x => x.idEmpresa == idEmpresa).FirstOrDefault();

                    freeler.nome = empresa.nome;
                    freeler.email = empresa.email;

                    dbContext.Update(freeler);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteFreelancer(int idEmpresa)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    Empresa empresa = dbContext.Empresa.AsQueryable().Where(x => x.idEmpresa == idEmpresa).FirstOrDefault();
                    dbContext.Remove(empresa);
                    EnderecoEmpresa endereco = dbContext.EnderecoEmpresa.AsQueryable().Where(x => x.idEmpresa == idEmpresa).FirstOrDefault();
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