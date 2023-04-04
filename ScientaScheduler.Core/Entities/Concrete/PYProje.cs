using ScientaScheduler.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Core.Entities.Concrete
{
    public class PYProje:IEntity
    {
        public int ID { get; set; }
        public int ProjeKodu { get; set; }
        public string ProjectAdi { get; set; }
        public DateTime PlanlananBaslamaTarihi { get; set; }
        public DateTime PlanlananBitisTarihi { get; set; }
        public int IsinSuresi { get; set; }
    }
}