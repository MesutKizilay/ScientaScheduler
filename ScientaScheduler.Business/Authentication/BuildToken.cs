using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScientaScheduler.Business.Authentication
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

        public string CreateToken(string[] loginKeys)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                signingCredentials: signingCredentials,
                claims: SetClaims(loginKeys)

                ); ;

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(token);

            //JwtSecurityToken securityToken = (JwtSecurityToken)handler.ReadToken(tokenString);
            //IEnumerable<Claim> claims = securityToken.Claims;

            return tokenString;
        }

        private IEnumerable<Claim> SetClaims(string[] loginKeys)
        {
            var claims = new List<Claim>()
            {
                new Claim("userFullName", loginKeys[1],ClaimValueTypes.String),
                //new Claim(ClaimTypes.Name, loginKeys[1]),
                new Claim("userId", loginKeys[0],ClaimValueTypes.Integer),
                new Claim("gırısAnahtarı",loginKeys[3],ClaimValueTypes.String)
            };
            return claims;
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