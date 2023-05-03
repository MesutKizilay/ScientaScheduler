using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.DTOs
{
    public class ActiveResource:IDto
    {
        public string Aktif { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public string AuthUserID { get; set; }
        public string GirisAnahtari { get; set; }
    }
}
