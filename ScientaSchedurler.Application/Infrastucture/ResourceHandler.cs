using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.DataAccess;
using ScientaSchedurler.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaSchedurler.Application.Infrastucture
{
    public class ResourceHandler : IResource
    {
        IEntityRepository<IKCalisan> _entityRepository;
        public ResourceHandler(IEntityRepository<IKCalisan> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<IKCalisan> GetResourceList()
        {
            return _entityRepository.GetAll();
        }
    }
}
