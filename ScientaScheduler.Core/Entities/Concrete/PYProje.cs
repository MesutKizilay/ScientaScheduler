using ScientaScheduler.Core.Entities.Abstarct;
using System;

namespace ScientaScheduler.Core.Entities.Concrete
{
    public class PYProje : IEntity
    {
        public int ID { get; set; }
        public int ProjeKodu { get; set; }
        public string ProjectAdi { get; set; }
        public DateTime PlanlananBaslamaTarihi { get; set; }
        public DateTime PlanlananBitisTarihi { get; set; }
        public int IsinSuresi { get; set; }
    }
}