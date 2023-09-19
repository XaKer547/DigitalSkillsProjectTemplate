using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Some.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Some.Api.Infrastructure
{
    public class JwtService : IJwtService
    {
        private readonly SymmetricSecurityKey _key;

        public JwtService(IConfiguration configuration)
        {
            var key = configuration["Jwt:Key"];

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public string CreateToken(int userId, params string[] roles)
        {
            var claims = new List<Claim>();

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(7),
                TokenType = JwtBearerDefaults.AuthenticationScheme,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
