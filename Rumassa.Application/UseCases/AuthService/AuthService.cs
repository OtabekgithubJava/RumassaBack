using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rumassa.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.AuthService
{
    public class AuthService : IAuthService
    {

        private IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWTSettings:Expire"]!);

            List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                    new Claim("UserId",user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name!),
                    new Claim(ClaimTypes.Surname, user.Surname!),
                    new Claim(ClaimTypes.Role, user.Role!)
                };



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWTSettings:ValidIssuer"],
                audience: _config["JWTSettings:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
