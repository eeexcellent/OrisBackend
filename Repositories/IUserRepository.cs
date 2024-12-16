using OrisBackend.Models;

namespace OrisBackend.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
    }
}