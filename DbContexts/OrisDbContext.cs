using Microsoft.EntityFrameworkCore;
using OrisBackend.Models;

namespace OrisBackend.DbContexts
{
    public class OrisDbContext : DbContext
    {
        public OrisDbContext(DbContextOptions<OrisDbContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}