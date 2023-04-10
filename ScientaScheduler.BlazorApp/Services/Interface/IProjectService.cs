
using ScientaScheduler.Blazor.Library.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Interface
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectById(int id);
        Task<List<ProjectDto>> GetProjectList();
        Task UpdateProject(ProjectDto projectDto);
    }
}