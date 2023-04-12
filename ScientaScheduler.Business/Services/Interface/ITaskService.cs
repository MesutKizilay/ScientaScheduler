using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Services.Interface
{
    public interface ITaskService
    {
        Task<List<GGorev>> GetActiveTaskList();

        Task<int> UpdateTask(GGorev gGorev);
        Task<int> DeleteTask(GGorev gGorev);
    }
}