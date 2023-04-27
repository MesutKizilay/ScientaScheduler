using Microsoft.JSInterop;
using ScientaScheduler.Blazor.Library.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Interface
{
    public interface IAuthService
    {
        Task<string> Login(UserForLoginDto userForLoginDto);
    }
}