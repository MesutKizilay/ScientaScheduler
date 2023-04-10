using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Blazor.Library.DTOs;
using ScientaScheduler.BlazorApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Infrastructure
{
    public class ProjectManager : IProjectService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public ProjectManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerBusinessSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ProjectDto> GetProjectById(int id)
        {
            ProjectDto proje = new();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await httpClient.GetAsync($"/Project/GetProjectById?id={id}");
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

        public async Task<List<ProjectDto>> GetProjectList()
        {
            List<ProjectDto> projes = new List<ProjectDto>();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await httpClient.GetAsync("/Project/GetProjectList");
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    projes = JsonConvert.DeserializeObject<List<ProjectDto>>(contentString);
                }
            }
            return projes;
        }
    }
}