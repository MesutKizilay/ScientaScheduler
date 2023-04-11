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
    public class TaskHandler:ITask
    {
        IEntityRepository<GGorev> _entityRepository;

        public TaskHandler(IEntityRepository<GGorev> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public void DeleteTask(GGorev gGorev)
        {
            _entityRepository.Delete(gGorev);
        }

        public GGorev GetTaskById(int id)
        {
            return _entityRepository.Get(p => p.ID0 == id);
        }

        public List<GGorev> GetTaskList()
        {
            return _entityRepository.GetAll();
        }

        public void UpdateTask(GGorev gGorev)
        {
            _entityRepository.Update(gGorev);
        }

        public void AddTask(GGorev gGorev)
        {
            _entityRepository.Add(gGorev);
        }
    }
}