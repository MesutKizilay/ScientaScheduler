using ScientaScheduler.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Core.Entities.Concrete
{
    public class GGorev:IEntity
    {
        public int ID { get; set; }
        public int? PYProjeKoduID { get; set; }
        public int? UstGorevID { get; set; }
        public DateTime? PlanlananBaslamaTarihi { get; set; }
        public DateTime? PlanlananBitisTarihi { get; set; }
        public int? Sure { get; set; }
        public string Konu { get; set; }
    }
}