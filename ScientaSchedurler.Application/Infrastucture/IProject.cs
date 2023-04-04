using ScientaScheduler.Core.Entities.Concrete;
using System.Collections.Generic;

namespace ScientaSchedurler.Application.Infrastucture
{
    public interface IProject
    {
        List<PYProje> GetProjectList();

        void GetProjectById(int id);

        void UpdateProject(PYProje pYProje);

        void DeleteProject(PYProje pYProje);
    }
}