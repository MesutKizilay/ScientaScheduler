using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ScientaScheduler.Authentication.JWT;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ScientaScheduler.Authentication.Authentication
{
    public class BuildToken : IAuthorization
    {
        readonly IConfiguration Configuration;
        TokenOptions _tokenOptions;

        public BuildToken(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public string CreateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = _tokenOptions.Audience,
                    ValidateAudience = true,
                    ValidIssuer = _tokenOptions.Issuer,
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