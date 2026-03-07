using Microsoft.EntityFrameworkCore;
using MonolithAPI.DBContext;
using MonolithAPI.Models;
using MonolithAPI.Repository.Interface;

namespace MonolithAPI.Repository.Implementation
{
    public class ApplicationRepo : IApplicationRepo
    {
        private ApplicationDBContext _dbContext;

        public ApplicationRepo(ApplicationDBContext dbContext) { 
        
            _dbContext = dbContext;
        }


        


        public async Task AddRefreshToken(RefreshToken refreshToken)
        {
            await _dbContext.refreshTokens.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> FindUserAsync(string Username, string HashedPassword)
        {
            var user = await _dbContext.users.FirstOrDefaultAsync(x => x.Username == Username & x.HashedPassword == HashedPassword);
            return user;
        }




        public async Task RemoveRefreshToken(Guid token)
        {
            await _dbContext.refreshTokens.Where(x=>x.refreshToken == token).ExecuteDeleteAsync();
        }

        public Role? GetRole(string RoleName) {

            var role = _dbContext.Roles.FirstOrDefault(x=> x.RoleName.Equals(RoleName));

            return role;
        
        
        
        }


    }
}
