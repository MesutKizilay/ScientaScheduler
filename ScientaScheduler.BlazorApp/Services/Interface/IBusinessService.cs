
using ScientaScheduler.Blazor.Library.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Interface
{
    public interface IBusinessService
    {
        Task<ProjectDto> GetProjectById();
        Task<List<ProjectDto>> GetProjectList();
    }
}
