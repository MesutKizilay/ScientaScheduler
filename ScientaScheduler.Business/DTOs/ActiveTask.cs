using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.DTOs
{
    public class ActiveTask
    {
        public string CariHesapID { get; set; }
        public string AramaMetni { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public string CalisanID { get; set; }
        public string GirisAnahtari { get; set; }
    }
}