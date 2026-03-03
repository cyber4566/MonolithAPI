
using Microsoft.EntityFrameworkCore;
using MonolithAPI.Models;

namespace MonolithAPI.DBContext
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {

        public DbSet<User> users { get; set; }

        public DbSet<RefreshToken> refreshTokens { get; set; }

        public DbSet<Role> Roles { get; set; }



    }
}
