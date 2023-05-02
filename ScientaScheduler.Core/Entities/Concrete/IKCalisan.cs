using ScientaScheduler.Core.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaScheduler.Core.Entities.Concrete
{
    public class IKCalisan:IEntity
    {
        public int ID { get; set; }
        public string AdiSoyadi { get; set; }
    }
}