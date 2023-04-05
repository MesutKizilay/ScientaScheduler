using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ScientaScheduler.Blazor.Library;
using ScientaScheduler.BlazorApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Infrastructure
{
    public class BusinessManager : IBusinessService
    {
        private HttpClient httpClient;

        private readonly IConfiguration configuration;

        public BusinessManager(HttpClient httpClient, IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new();
            httpClient.BaseAddress = new Uri(configuration["SchedulerBusinessSettings:BaseUrl"]); 
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Göstermek için bir fonksiyon yazıyorum.
        public async Task<ProjectDto> GetProjeById()
        {
            ProjectDto proje = new();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Eğer business katmanında oluşturduğumuz controller [Authorization] ile korunuyor ise
            //kendisine token vermemiz gerekecektir. tabi burada elimizde bir token olması gerekir.
            //şimdilik controller [Auth] ile korunmadığından bunu yorum satırı haline alıyorum
            //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            // Burada artık isteklerini gönderiyorsun
            // hangi adrese yukarıda belirttiğin baseAdress e
            // ama biz dapper yapmıyacağız şimdilik base i kullanacağız

            // şimdi buraya business da bulunan getbyıd adresine bir get isteği oluşturup onu da bir listeye aktarır mısın


            using HttpResponseMessage response = await httpClient.GetAsync("/Project/GetProjectById?id=1");
            // onun için gelen nesneyi çevirmemiz gerekecek
            // ama ondan önce bir satır daha yazmam lazım gelen bir konu daha var
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