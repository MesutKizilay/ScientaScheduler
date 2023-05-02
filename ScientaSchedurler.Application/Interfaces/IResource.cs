using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaSchedurler.Application.Interfaces
{
    public interface IResource
    {
        List<IKCalisan> GetResourceList();
    }
}
