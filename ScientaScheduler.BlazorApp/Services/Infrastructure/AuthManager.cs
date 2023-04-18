using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Blazor.Library.DTOs;
using ScientaScheduler.BlazorApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Infrastructure
{
    public class AuthManager : IAuthService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public AuthManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerBusinessSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Login(UserForLoginDto userForLoginDto)
        {
            string loginKey="";
            string serializeProject = JsonConvert.SerializeObject(userForLoginDto);

            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/Auth/Login", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                //loginKeys = contentString.Split("$");
                if (!string.IsNullOrEmpty(contentString))
                {
                    loginKey = JsonConvert.DeserializeObject<string>(contentString);
                }
            }
            return loginKey;
            //JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(loginKey);
            //string name = securityToken.Claims.First(c=>c.Type=="userFullName").Value;
            //return name;
            //var token = new JwtSecurityToken(jwtEncodedString: contentString);
            //string expiry = token.Claims.First(c => c.Type == "userFullName").Value;
            //return expiry;

            //var token = new JwtSecurityTokenHandler().CanReadToken(contentString);
            //var claim = token.Claims.First(c => c.Type == "Name").Value;



            //if (_httpContextAccessor.HttpContext != null)
            //{
            //    name = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
            //}






            //var token = contentString;
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(contentString);
            //var jti = jwtSecurityToken.Claims.First(claim => claim.Type == "userFullName").Value;

            //var stream = contentString;
            //var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(stream);
            //var tokenS = jsonToken as JwtSecurityToken;
            //var jti = tokenS.Claims.First(claim => claim.Type == "userFullName").Value;



            //loginKeys = contentString.Split("$");
            //if (response.IsSuccessStatusCode)
            //{
            //    var contentString = await response.Content.ReadAsStringAsync();
            //    loginKeys = contentString.Split("$");
            //    //if (!string.IsNullOrEmpty(contentString))
            //    //{
            //    //    loginKey = JsonConvert.DeserializeObject<string>(contentString);
            //    //}                
            //}
            //return name;
        }
    }
}