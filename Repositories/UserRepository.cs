using Microsoft.EntityFrameworkCore;
using OrisBackend.DbContexts;
using OrisBackend.Models;

namespace OrisBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OrisDbContext _context;

        public UserRepository(OrisDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}