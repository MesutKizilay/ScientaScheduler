using ScientaScheduler.Core.Entities.Abstarct;
using System;

namespace ScientaScheduler.Core.Entities.Concrete
{
    public class PYProje : IEntity
    {
        public int ID { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public DateTime? PlanlananBaslamaTarihi { get; set; }
        public DateTime? PlanlananBitisTarihi { get; set; }
        public short? IsinSuresi { get; set; }
    }
}