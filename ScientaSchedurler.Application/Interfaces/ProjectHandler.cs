using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.DataAccess;
using ScientaSchedurler.Application.Infrastucture;

namespace ScientaSchedurler.Application.Interfaces
{
    public class ProjectHandler : IProject
    {
        IEntityRepository<PYProje> _entityRepository;
        public ProjectHandler(IEntityRepository<PYProje> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public void DeleteProject(PYProje pYProje)
        {
            _entityRepository.Delete(pYProje);
        }

        public void GetProjectById(int id)
        {
            _entityRepository.Get(p => p.ID == id);
        }

        public void GetProjectList()
        {
            _entityRepository.GetAll();
        }

        public void UpdateProject(PYProje pYProje)
        {
            _entityRepository.Update(pYProje);
        }
    }
}