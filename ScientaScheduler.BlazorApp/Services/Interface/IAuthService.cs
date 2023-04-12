using ScientaScheduler.Blazor.Library.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.BlazorApp.Services.Interface
{
    public interface IAuthService
    {
        void Login(UserForLoginDto userForLoginDto);
    }
}
