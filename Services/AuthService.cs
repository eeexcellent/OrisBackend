using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OrisBackend.DTOs;
using OrisBackend.Models;
using OrisBackend.Repositories;

namespace OrisBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthResponseDto> SignInAsync(string idToken)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);

                var user = await _userRepository.GetUserByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = payload.Email,
                        FullName = payload.Name,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _userRepository.AddUserAsync(user);
                }

                // Generating JWT
                // var token = GenerateJwtToken(user);
                var token = "JWTtoken231458908239179213";
                return new AuthResponseDto
                {
                    AccessToken = token,
                    User = new UserDto
                    {
                        Email = user.Email,
                        Name = user.FullName,
                        CreatedAt = user.CreatedAt,
                    }
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

