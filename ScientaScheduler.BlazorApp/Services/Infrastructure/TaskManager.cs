using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Blazor.Library.DTOs;
using ScientaScheduler.BlazorApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Infrastructure
{
    public class TaskManager:ITaskService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public TaskManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerBusinessSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TaskDto> GetTaskById(int id)
        {
            TaskDto proje = new();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await httpClient.GetAsync($"/Task/GetTAskById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    proje = JsonConvert.DeserializeObject<TaskDto>(contentString);
                }
            }
            return proje;
        }

        public async Task<List<TaskDto>> GetTaskList()
        {
            List<TaskDto> projes = new List<TaskDto>();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await httpClient.GetAsync("/Task/GetTaskList");
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    projes = JsonConvert.DeserializeObject<List<TaskDto>>(contentString);
                }
            }
            return projes;
        }
    }
}