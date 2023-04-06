using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Blazor.Library.DTOs;
using ScientaScheduler.BlazorApp.Services.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Infrastructure
{
    public class BusinessManager : IBusinessService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public BusinessManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerBusinessSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ProjectDto> GetProjeById()
        {
            ProjectDto proje = new();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await httpClient.GetAsync("/Project/GetProjectById?id=1");
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    proje = JsonConvert.DeserializeObject<ProjectDto>(contentString);
                }
            }
            return proje;
        }
    }
}