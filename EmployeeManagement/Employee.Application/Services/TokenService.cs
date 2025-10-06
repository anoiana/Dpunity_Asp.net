using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly double _duration;

        public TokenService(IConfiguration config)
        {
            _issuer = config["Jwt:Issuer"];
            _audience = config["Jwt:Audience"];
            _duration = double.Parse(config["Jwt:DurationInMinutes"]);
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        public string CreateToken(IEnumerable<Claim> claims)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),            
                Expires = DateTime.UtcNow.AddMinutes(_duration), 
                SigningCredentials = credentials,                
                Issuer = _issuer,                                
                Audience = _audience                             
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
