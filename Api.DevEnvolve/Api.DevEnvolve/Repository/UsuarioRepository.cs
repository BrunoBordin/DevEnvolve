using Api.DevEnvolve.Data;
using Api.DevEnvolve.Helper;
using Api.DevEnvolve.Model;
using static Api.DevEnvolve.Helper.Extension;

namespace Api.DevEnvolve.Repository
{
    public class UsuarioRepository
    {
        public static void AddUsuario(Usuario usuario)
        {
            try
            {
                if (usuario.tipo.ToLower().Trim().Contains("freela"))
                {
                    var encod = new DefaultSGUPasswordEncoderHandler();
                    var senhaCripto = encod.encodePlainPassword(encod.plainPassword(usuario.email, usuario.senha));

                    Freelancer userFreelancer = new Freelancer
                    {
                        nome = usuario.nome,
                        email = usuario.email,
                        senha = senhaCripto,
                        celular = Extension.RemoveNonNumeric(usuario.celular),
                    };

                    Endereco endereco = new()
                    {
                        cidade = usuario.cida
                    }
                    using (var dbContext = new DataContext())
                    {
                        dbContext.Feelancer.Add(userFreelancer);
                        dbContext.SaveChanges();
                        userFreelancer.idFreelancer = userFreelancer.idFreelancer;

                    }
                }
                else
                {
                    var encod = new DefaultSGUPasswordEncoderHandler();
                    var senhaCripto = encod.encodePlainPassword(encod.plainPassword(usuario.email, usuario.senha));

                    Empresa userEmpresa = new Empresa
                    {
                        nome = usuario.nome,
                        email = usuario.email,
                        senha = senhaCripto,
                        celular = Extension.RemoveNonNumeric(usuario.celular),
                    };

                    using (var dbContext = new DataContext())
                    {
                        dbContext.Empresa.Add(userEmpresa);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}