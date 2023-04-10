using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaSchedurler.Application.Interfaces
{
    public interface ITask
    {
        List<GGorev> GetTaskList();
        GGorev GetTaskById(int id);
        void UpdateTask(GGorev gGorev);
        void DeleteTask(GGorev gGorev);
        void AddTask(GGorev gGorev);
    }
}