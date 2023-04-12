using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.DTOs
{
    public class DeleteTask
    {
        public string GorevID { get; set; }
        public string CalisanID { get; set; }
        public string GirisAnahtari { get; set; }
    }
}