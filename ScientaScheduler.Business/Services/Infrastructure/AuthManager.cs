using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Business.DTOs;
using ScientaScheduler.Business.Services.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Authentication
{
    public class AuthManager : IAuthService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public AuthManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerRestSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string[]> Login(UserForLoginDto userForLoginDto)
        {
            //string loginKey = "";
            string[] loginKeys;
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["SchedulerRestSettings:Password"] + ":" + configuration["SchedulerRestSettings:UserName"]));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
           

            string serializeProject = JsonConvert.SerializeObject(userForLoginDto);

            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("Login", stringContent);

            var contentString = await response.Content.ReadAsStringAsync();
            loginKeys = contentString.Split("$");
            //if (response.IsSuccessStatusCode)
            //{
            //    var contentString = await response.Content.ReadAsStringAsync();
            //    loginKeys = contentString.Split("$");
            //    //if (!string.IsNullOrEmpty(contentString))
            //    //{
            //    //    loginKey = JsonConvert.DeserializeObject<string>(contentString);
            //    //}                
            //} 
            
            return loginKeys;
        }
    }
}