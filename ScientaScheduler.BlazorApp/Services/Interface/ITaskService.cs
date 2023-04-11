using ScientaScheduler.Blazor.Library.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Interface
{
    public interface ITaskService
    {
        Task<TaskDto> GetTaskById(int id);
        Task<List<TaskDto>> GetTaskList();
        Task<int> UpdateTask(TaskDto taskDto);
        Task<List<TaskDto>> GetActiveTaskList();
    }
}
