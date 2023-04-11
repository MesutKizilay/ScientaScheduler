using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Blazor.Library.DTOs
{
    //    public class TaskDto
    //    {
    //        public int ID { get; set; }
    //        public int? PYProjeKoduID { get; set; }
    //        public int? UstGorevID { get; set; }
    //        public DateTime? PlanlananBaslamaTarihi { get; set; }
    //        public DateTime? PlanlananBitisTarihi { get; set; }
    //        public int? Sure { get; set; }
    //        public string Konu { get; set; }
    //    }
    public class TaskDto
    {
        public int ID0 { get; set; }
        public int? PYProjeKoduID { get; set; }
        //public int? UstGorevID { get; set; }
        public DateTime? PlanlananBaslamaTarihi { get; set; }
        public DateTime? PlanlananBitisTarihi { get; set; }
        //public int? Sure { get; set; }
        public string Konu { get; set; }
    }

    //public class TaskDto
    //{
    //    public int ID0 { get; set; }
    //    public bool ID0Specified { get; set; }
    //    public object ID0Default { get; set; }
    //    public int? PYProjeKoduID { get; set; }
    //    public bool PYProjeKoduIDSpecified { get; set; }
    //    public object PYProjeKoduIDDefault { get; set; }
    //    public bool PYGorevTuruSpecified { get; set; }
    //    public object PYGorevTuruDefault { get; set; }
    //    public bool PYKrediPuaniSpecified { get; set; }
    //    public object PYKrediPuaniDefault { get; set; }
    //    public bool PYFaturalanmamaNedeniIDSpecified { get; set; }
    //    public object PYFaturalanmamaNedeniIDDefault { get; set; }
    //    public bool YMMusteriIstekSikayetIDSpecified { get; set; }
    //    public object YMMusteriIstekSikayetIDDefault { get; set; }
    //    public bool ToplantiKatilimcisiIDSpecified { get; set; }
    //    public object ToplantiKatilimcisiIDDefault { get; set; }
    //    public bool GundemMaddesiIDSpecified { get; set; }
    //    public object GundemMaddesiIDDefault { get; set; }
    //    public bool HDonemHedefIDSpecified { get; set; }
    //    public object HDonemHedefIDDefault { get; set; }
    //    public bool HHedeflenenSpecified { get; set; }
    //    public object HHedeflenenDefault { get; set; }
    //    public bool HGerceklesenSpecified { get; set; }
    //    public object HGerceklesenDefault { get; set; }
    //    public bool UretimPlaniIDSpecified { get; set; }
    //    public object UretimPlaniIDDefault { get; set; }
    //    public bool DOFIDSpecified { get; set; }
    //    public object DOFIDDefault { get; set; }
    //    public bool IsAkisVeriIDSpecified { get; set; }
    //    public object IsAkisVeriIDDefault { get; set; }
    //    public bool SiparisDetayiIDSpecified { get; set; }
    //    public object SiparisDetayiIDDefault { get; set; }
    //    public bool TanimliGorevIDSpecified { get; set; }
    //    public object TanimliGorevIDDefault { get; set; }
    //    public bool UstGorevIDSpecified { get; set; }
    //    public object UstGorevIDDefault { get; set; }
    //    public string Konu { get; set; }
    //    public bool KonuSpecified { get; set; }
    //    public object KonuDefault { get; set; }
    //    public string Aciklama { get; set; }
    //    public bool AciklamaSpecified { get; set; }
    //    public object AciklamaDefault { get; set; }
    //    public string Oncelik { get; set; }
    //    public bool OncelikSpecified { get; set; }
    //    public object OncelikDefault { get; set; }
    //    public bool KisiOnculSpecified { get; set; }
    //    public object KisiOnculDefault { get; set; }
    //    public int OlayTuru { get; set; }
    //    public bool OlayTuruSpecified { get; set; }
    //    public string OlayTuruDefault { get; set; }
    //    public DateTime? PlanlananBaslamaTarihi { get; set; }
    //    public bool PlanlananBaslamaTarihiSpecified { get; set; }
    //    public object PlanlananBaslamaTarihiDefault { get; set; }
    //    public DateTime? PlanlananBitisTarihi { get; set; }
    //    public bool PlanlananBitisTarihiSpecified { get; set; }
    //    public object PlanlananBitisTarihiDefault { get; set; }
    //    public bool SureSpecified { get; set; }
    //    public object SureDefault { get; set; }
    //    public bool PlanlananSureSpecified { get; set; }
    //    public object PlanlananSureDefault { get; set; }
    //    public bool HatirlatmaSpecified { get; set; }
    //    public object HatirlatmaDefault { get; set; }
    //    public bool HatirlatmaTarihiSpecified { get; set; }
    //    public object HatirlatmaTarihiDefault { get; set; }
    //    public bool YinelemeSpecified { get; set; }
    //    public object YinelemeDefault { get; set; }
    //    public bool YinelemeTuruSpecified { get; set; }
    //    public object YinelemeTuruDefault { get; set; }
    //    public bool YinelemeSuresiSpecified { get; set; }
    //    public object YinelemeSuresiDefault { get; set; }
    //    public bool ButunGunSpecified { get; set; }
    //    public object ButunGunDefault { get; set; }
    //    public int Durumu { get; set; }
    //    public bool DurumuSpecified { get; set; }
    //    public object DurumuDefault { get; set; }
    //    public bool TamamlananSpecified { get; set; }
    //    public object TamamlananDefault { get; set; }
    //    public bool RandevuTuruSpecified { get; set; }
    //    public object RandevuTuruDefault { get; set; }
    //    public bool OlayYeriSpecified { get; set; }
    //    public object OlayYeriDefault { get; set; }
    //    public bool IlgiliKontakSpecified { get; set; }
    //    public object IlgiliKontakDefault { get; set; }
    //    public bool IlgiliCalisanSpecified { get; set; }
    //    public object IlgiliCalisanDefault { get; set; }
    //    public bool MusteriKoduSpecified { get; set; }
    //    public object MusteriKoduDefault { get; set; }
    //    public bool FirsatSpecified { get; set; }
    //    public object FirsatDefault { get; set; }
    //    public bool EklentiDosyaAdiSpecified { get; set; }
    //    public object EklentiDosyaAdiDefault { get; set; }
    //    public string Uygulama { get; set; }
    //    public bool UygulamaSpecified { get; set; }
    //    public object UygulamaDefault { get; set; }
    //    public int EkleyenCalisanID { get; set; }
    //    public bool EkleyenCalisanIDSpecified { get; set; }
    //    public object EkleyenCalisanIDDefault { get; set; }
    //    public DateTime EklemeTarihi { get; set; }
    //    public bool EklemeTarihiSpecified { get; set; }
    //    public object EklemeTarihiDefault { get; set; }
    //    public int DuzenleyenCalisanID { get; set; }
    //    public bool DuzenleyenCalisanIDSpecified { get; set; }
    //    public object DuzenleyenCalisanIDDefault { get; set; }
    //    public DateTime DuzenlemeTarihi { get; set; }
    //    public bool DuzenlemeTarihiSpecified { get; set; }
    //    public object DuzenlemeTarihiDefault { get; set; }
    //    public bool SonErisenCalisanIDSpecified { get; set; }
    //    public object SonErisenCalisanIDDefault { get; set; }
    //    public bool SonErisimSpecified { get; set; }
    //    public object SonErisimDefault { get; set; }
    //    public bool GerceklesenBaslamaTarihiSpecified { get; set; }
    //    public object GerceklesenBaslamaTarihiDefault { get; set; }
    //    public bool GerceklesenBitisTarihiSpecified { get; set; }
    //    public object GerceklesenBitisTarihiDefault { get; set; }
    //    public bool TerminTarihiSpecified { get; set; }
    //    public object TerminTarihiDefault { get; set; }
    //    public bool TamamlanmaDurumuSpecified { get; set; }
    //    public object TamamlanmaDurumuDefault { get; set; }
    //    public int Sorumlu { get; set; }
    //    public bool SorumluSpecified { get; set; }
    //    public object SorumluDefault { get; set; }
    //    public bool ProjeUnvaniIDSpecified { get; set; }
    //    public object ProjeUnvaniIDDefault { get; set; }
    //    public bool ProjeTakimiIDSpecified { get; set; }
    //    public object ProjeTakimiIDDefault { get; set; }
    //    public bool SonucSpecified { get; set; }
    //    public object SonucDefault { get; set; }
    //    public bool EnlemSpecified { get; set; }
    //    public object EnlemDefault { get; set; }
    //    public bool BoylamSpecified { get; set; }
    //    public object BoylamDefault { get; set; }
    //    public bool MesafeSpecified { get; set; }
    //    public object MesafeDefault { get; set; }
    //    public bool LYAracIDSpecified { get; set; }
    //    public object LYAracIDDefault { get; set; }
    //    public bool LYAracTipiIDSpecified { get; set; }
    //    public object LYAracTipiIDDefault { get; set; }
    //    public bool LYAdresSpecified { get; set; }
    //    public object LYAdresDefault { get; set; }
    //    public bool LYAdresIlSpecified { get; set; }
    //    public object LYAdresIlDefault { get; set; }
    //    public bool LYIlceSpecified { get; set; }
    //    public object LYIlceDefault { get; set; }
    //    public bool LYSemtSpecified { get; set; }
    //    public object LYSemtDefault { get; set; }
    //    public bool LYDegerlendirmeTarihiSpecified { get; set; }
    //    public object LYDegerlendirmeTarihiDefault { get; set; }
    //    public bool LYDegerlendirenSpecified { get; set; }
    //    public object LYDegerlendirenDefault { get; set; }
    //    public bool LYOnaySpecified { get; set; }
    //    public object LYOnayDefault { get; set; }
    //    public bool IIZiyaretciAdiSpecified { get; set; }
    //    public object IIZiyaretciAdiDefault { get; set; }
    //    public bool IIZiyaretciSoyadiSpecified { get; set; }
    //    public object IIZiyaretciSoyadiDefault { get; set; }
    //    public bool IIZiyaretciFirmaAdiSpecified { get; set; }
    //    public object IIZiyaretciFirmaAdiDefault { get; set; }
    //    public bool IIZiyaretciDogumTarihiSpecified { get; set; }
    //    public object IIZiyaretciDogumTarihiDefault { get; set; }
    //    public bool IIZiyaretciTCNoSpecified { get; set; }
    //    public object IIZiyaretciTCNoDefault { get; set; }
    //    public bool IIZiyaretciGSMSpecified { get; set; }
    //    public object IIZiyaretciGSMDefault { get; set; }
    //    public bool IIZiyaretciKartNoSpecified { get; set; }
    //    public object IIZiyaretciKartNoDefault { get; set; }
    //    public bool IIBilgisayarSeriNoSpecified { get; set; }
    //    public object IIBilgisayarSeriNoDefault { get; set; }
    //    public TableAccess TableAccess { get; set; }
    //    public bool IsReadOnly { get; set; }
    //    public bool IsCreated { get; set; }
    //    public PrimaryKeyValue PrimaryKeyValue { get; set; }
    //    public bool IsExistsInDatabase { get; set; }
    //    public bool IsAnyValueChanged { get; set; }
    //    public string GirisAnahtari { get; set; }
    //}
    //public class TableAccess
    //{
    //}
    //public class PrimaryKeyValue
    //{
    //    public int Count { get; set; }
    //    public bool IsNull { get; set; }
    //}
}