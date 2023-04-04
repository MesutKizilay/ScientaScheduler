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

        void GetProjectById();

        void UpdateProject();

        void DeleteProject();
    }
}
