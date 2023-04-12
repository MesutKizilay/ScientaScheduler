using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.DTOs
{
    //public class UpdateTask
    //{
    //    public int ID0 { get; set; }
    //    public int? PYProjeKoduID { get; set; }
    //    //public int? UstGorevID { get; set; }
    //    public DateTime? PlanlananBaslamaTarihi { get; set; }
    //    public DateTime? PlanlananBitisTarihi { get; set; }
    //    //public int? Sure { get; set; }
    //    public string Konu { get; set; }
    //}
    public class Json
    {
        public string ID { get; set; }
        public string MusteriKodu { get; set; }
        public string PYProjeKoduID { get; set; }
        public string PYKilometreTasiID { get; set; }
        public string Durumu { get; set; }
        public string Sonuc { get; set; }
        public string Faturalanacak { get; set; }
        public string FaturalanmamaNedeni { get; set; }
        public string FaturaAciklama { get; set; }
        public string OlayTuru { get; set; }
        public string Konu { get; set; }
        public string Sorumlu { get; set; }
        public string PlanlananBaslamaTarihi { get; set; }
        public string PlanlananBitisTarihi { get; set; }
        public string GPSEnlem { get; set; }
        public string GPSBoylam { get; set; }
        public string Aciklama { get; set; }
    }

    public class UpdateTask
    {
        public string CalisanID { get; set; }
        public string Application { get; set; }
        public string GirisAnahtari { get; set; }
        public List<Json> Json { get; set; }
    }
}
