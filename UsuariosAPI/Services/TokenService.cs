using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class TokenService
    {

        public Token CreateToken(IdentityUser<int> usuario, string role)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var chave = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes("TuRCN9CoqGc0d2rWMc0pR4suqf8L4OVUlx80cVqLegfxw8M7OqsEcbYXIqKsR164")
            );

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(2)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }

        public Token CreateToken(IdentityUser<int> usuario)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes("TuRCN9CoqGc0d2rWMc0pR4suqf8L4OVUlx80cVqLegfxw8M7OqsEcbYXIqKsR164")
            );

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(2)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}
