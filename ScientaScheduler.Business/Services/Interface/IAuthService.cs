using ScientaScheduler.Business.DTOs;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Services.Interface
{
    public interface IAuthService
    {
        Task<string[]> Login(UserForLoginDto userForLoginDto);
    }
}