using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Application.Interfaces;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class TokenService : ITokenServices
    {
        
        public Token CreateToken(IdentityUser<int> usuario) {

            Claim[] direitosUsuario = new Claim[] {

                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };
            
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
                );

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                    claims: direitosUsuario,
                    signingCredentials: credenciais,
                    expires: DateTime.UtcNow.AddHours(8),
                    audience: "suaAudience",
                    issuer: "suaIssuer"

                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}
