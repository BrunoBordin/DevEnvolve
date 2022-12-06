using Api.DevEnvolve.Helper;
using Api.DevEnvolve.Model;
using Api.DevEnvolve.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Api.DevEnvolve.Helper.Extension;

namespace Api.DevEnvolve.Controllers
{
    public class TokenController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> RequestTokenAsync([FromBody] UsuarioToken user)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            try
            {
                UsuarioToken usuario = new UsuarioToken();

                if (user.tipo.Trim().ToLower().Contains("freela"))
                    usuario = FreelancerRepository.GetFreelancerByLogin(user.email, user.senha);
                else
                    usuario = EmpresaRepository.GetEmpresaByLogin(user.email, user.senha);

                if (usuario == null)
                    return Accepted(value: new string("Usuário ou Senha inválidos"));

                //Usuario logado
                var claims = new List<Claim>
                {
                      new Claim(ClaimTypes.PrimarySid, usuario.email.ToUpper() , ClaimValueTypes.String),
                      new Claim(CustomClaimTypes.id, usuario.id.ToString(), ClaimValueTypes.Integer)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                DateTime expires = DateTime.Now.AddYears(1);
                var token = new JwtSecurityToken(
                    issuer: configuration["Issuer"],
                    audience: configuration["Audience"],
                    claims: claims,
                    expires: expires,
                    signingCredentials: creds
                );
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{HttpContext.Request.Host.Value}: {ex} {Environment.NewLine}Inner: {ex.InnerException.ToNullSafeString()}");
            }
        }
    }
}