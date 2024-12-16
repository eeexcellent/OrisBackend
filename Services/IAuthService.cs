using OrisBackend.DTOs;
using OrisBackend.Models;

namespace OrisBackend.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> SignInAsync(string idToken);
    }
}
