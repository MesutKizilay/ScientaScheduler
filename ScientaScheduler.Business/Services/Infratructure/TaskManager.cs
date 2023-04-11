using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Services.Infratructure
{
    public class TaskManager : ITaskService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public TaskManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerRestSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<GGorev>> GetActiveTaskList()
        {
            List<GGorev> projes = new List<GGorev>();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response = await httpClient.GetAsync("AktifGorevListesi");
           
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    projes = JsonConvert.DeserializeObject<List<GGorev>>(contentString);
                }
            }
            return projes;
        }
    }
}