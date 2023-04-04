using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaSchedurler.Application.Infrastucture
{
    public interface IProject
    {
        void GetProjectList();

        void GetProjectById(int id);

        void UpdateProject(PYProje pYProje);

        void DeleteProject(PYProje pYProje);
    }
}