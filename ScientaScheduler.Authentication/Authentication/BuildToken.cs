using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Authentication.JWT
{
    public class BuildToken
    {
        IConfiguration Configuration;
        public BuildToken(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string CreateToken()
        {
            var issuer = Configuration["JwtConfig:Issuer"];
            var audience = Configuration["JwtConfig:Audience"];
            var signingKey = Configuration["JwtConfig:SigningKey"];
            var bytes = Encoding.UTF8.GetBytes(signingKey);

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
