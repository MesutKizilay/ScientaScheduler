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

namespace ScientaScheduler.Business.Services.Infrstructure
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
            List<GGorev> gorevler = new List<GGorev>();

            ActiveTask activeTask = new ActiveTask() { AramaMetni = "", CalisanID = "6", CariHesapID = "", GirisAnahtari = "", PageIndex = "0", PageSize = "100" };
            
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["SchedulerRestSettings:Password"]+":"+configuration["SchedulerRestSettings:UserName"]));
            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);

            string serializeProject = JsonConvert.SerializeObject(activeTask);

            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("AktifGorevListesi", stringContent);


            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    gorevler = JsonConvert.DeserializeObject<List<GGorev>>(contentString);
                }
            }
            return gorevler;
        }

        public async Task<int> UpdateTask(GGorev gGorev)
        {
            List<Json> jsons = new List<Json>() { new Json {ID="291",PYProjeKoduID="",PYKilometreTasiID="1",Aciklama="",Durumu="3",
                     FaturaAciklama="",Faturalanacak="",FaturalanmamaNedeni="",GPSBoylam="",GPSEnlem="",Konu= "RET SÜRECİ TESTİ 2"
                     ,MusteriKodu="",OlayTuru="",PlanlananBaslamaTarihi="",PlanlananBitisTarihi="",Sonuc="",Sorumlu="6" } };

            UpdateTask updateTask = new UpdateTask() { Application = "ScientaWeb", CalisanID = "428", GirisAnahtari = "", Json= jsons};

            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["SchedulerRestSettings:Password"] + ":" + configuration["SchedulerRestSettings:UserName"]));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);

            string serializeProject = JsonConvert.SerializeObject(updateTask);

            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("UpdateGorev", stringContent);

            return (int)response.StatusCode;
        }
    }
}