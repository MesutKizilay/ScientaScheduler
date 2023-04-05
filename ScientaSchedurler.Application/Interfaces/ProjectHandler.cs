using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.DataAccess;
using ScientaSchedurler.Application.Infrastucture;
using System.Collections.Generic;

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

        public PYProje GetProjectById(int id)
        {
            return _entityRepository.Get(p => p.ID == id);
        }

        public List<PYProje> GetProjectList()
        {
            //List<PYProje> projects = new();
            return _entityRepository.GetAll();
            //return projects;
        }

        public void UpdateProject(PYProje pYProje)
        {
            _entityRepository.Update(pYProje);
        }

        public void AddProject(PYProje pYProje)
        {
            _entityRepository.Add(pYProje);
        }
    }
}