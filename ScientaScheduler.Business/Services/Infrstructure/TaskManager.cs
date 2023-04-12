using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

            Root root = new Root() { AramaMetni = "", CalisanID = "6", CariHesapID = "", GirisAnahtari = "", PageIndex = "0", PageSize = "100" };
            
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes("scienta:scienta"));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);

            string serializeProject = JsonConvert.SerializeObject(root);

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
            //List<GGorev> projes = new List<GGorev>();

            //httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.DefaultRequestHeaders.Clear();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //using HttpResponseMessage response = await httpClient.GetAsync("AktifGorevListesi");

            //if (response.IsSuccessStatusCode)
            //{
            //    var contentString = await response.Content.ReadAsStringAsync();
            //    if (!string.IsNullOrEmpty(contentString))
            //    {
            //        projes = JsonConvert.DeserializeObject<List<GGorev>>(contentString);
            //    }
            //}
            //return projes;
        }

        public async Task UpdateTask(GGorev gGorev)
        {
            string serializeProject = JsonConvert.SerializeObject(gGorev);

            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("UpdateGorev", stringContent);
        }
    }
    public class Root
    {
        public string CariHesapID { get; set; }
        public string AramaMetni { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public string CalisanID { get; set; }
        public string GirisAnahtari { get; set; }
    }
}