using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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

        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:SigningKey"]));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = Configuration["JwtConfig:Audience"],
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],
                    ValidateIssuer = true,
                }, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
