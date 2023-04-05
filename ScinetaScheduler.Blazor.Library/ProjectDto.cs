using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Blazor.Library
{
    public class ProjectDto
    {
        public int ID { get; set; }
        public string ProjeKodu { get; set; }
        public string ProjeAdi { get; set; }
        public DateTime? PlanlananBaslamaTarihi { get; set; }
        public DateTime? PlanlananBitisTarihi { get; set; }
        public short? IsinSuresi { get; set; }
    }
}