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
                    List<Empresa> empresas = dbContext.Empresa.AsQueryable().ToList();

                    return empresas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Empresa GetEmpresaByName(string nomeEmpresa)
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
                        //EnderecoEmpresa endereco = dbContext.EnderecoEmpresa.AsQueryable().Where(x => x.idEmpresa == empresa.idEmpresa).FirstOrDefault();
                        //dbContext.Remove(endereco);
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

                    Empresa? empresa = dbContext.Empresa.AsQueryable().Where(x => x.email == email && x.senha == senha).FirstOrDefault();
                    if (empresa != null)
                    {
                        UsuarioToken usuarioToken = new UsuarioToken()
                        {
                            id = empresa.idEmpresa,
                            email = empresa.email,
                            senha = empresa.senha
                        };
                    }
                    else return null;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}