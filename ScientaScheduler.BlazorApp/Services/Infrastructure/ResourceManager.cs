using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Blazor.Library.DTOs;
using ScientaScheduler.BlazorApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Infrastructure
{
    public class ResourceManager : IResourceService
    {
        private HttpClient httpClient;
        private readonly IConfiguration configuration;
        public ResourceManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerBusinessSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<ResourceDto> GetResourceList()
        {
            List<ResourceDto> resources = new List<ResourceDto>();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using HttpResponseMessage response =  httpClient.GetAsync("/Resource/GetResourceList").Result;
            
            if (response.IsSuccessStatusCode)
            {
                var contentString =  response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(contentString))
                {
                    resources = JsonConvert.DeserializeObject<List<ResourceDto>>(contentString);
                }
            }
            return resources;
        }
    }
}