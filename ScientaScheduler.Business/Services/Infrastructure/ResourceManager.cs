using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Business.DTOs;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Services.Infrastructure
{
    public class ResourceManager : IResourceService
    {
        private HttpClient httpClient;
        private readonly IConfiguration configuration;

        public ResourceManager(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["SchedulerRestSettings:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<IKCalisan>> GetResourceList()
        {
            List<IKCalisan> calisanlar = new List<IKCalisan>();

           ActiveResource activeResource = new ActiveResource() { Aktif="Aktif",AuthUserID="6",GirisAnahtari="",PageIndex="0",PageSize="1000" };

            var stringContent = InitializeForJSONFormat(activeResource);

            var response = await httpClient.PostAsync("AktifPersonelListesi", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    calisanlar = JsonConvert.DeserializeObject<List<IKCalisan>>(contentString);
                }
            }
            return calisanlar;
        }

        private StringContent InitializeForJSONFormat(IDto dto)
        {
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["SchedulerRestSettings:Password"] + ":" + configuration["SchedulerRestSettings:UserName"]));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);

            string serializeProject = JsonConvert.SerializeObject(dto);

            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}