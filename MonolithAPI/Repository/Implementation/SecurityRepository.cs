using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MonolithAPI.DBContext;
using MonolithAPI.Models;
using MonolithAPI.Repository.Interface;

namespace MonolithAPI.Repository.Implementation
{
    public class SecurityRepository : ISecurityRepository
    {
        private ApplicationDBContext _dbContext;

        public SecurityRepository(ApplicationDBContext dbContext) { 
        
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

        public async Task<User?> FindUserAsync(string Username, string password, PasswordHasher<string> hasher)
        {
            var user = await _dbContext.users.Include(u => u.Role).FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
            {

                return null;

            }

            else {

                var passwordVerification = hasher.VerifyHashedPassword(user.Username,user.HashedPassword,password);

                if (passwordVerification == PasswordVerificationResult.Success || passwordVerification == PasswordVerificationResult.SuccessRehashNeeded)
                {

                    return user;

                }
                else {

                    return null;
                
                }


            
            }

                
        }




        public async Task RemoveRefreshToken(Guid token)
        {
            await _dbContext.refreshTokens.Where(x=>x.refreshToken == token).ExecuteDeleteAsync();
        }

        public Role? GetRole(string RoleName) {

            var role = _dbContext.Role.FirstOrDefault(x=> x.RoleName.Equals(RoleName));

            return role;
        
        
        
        }

        public async Task<User?> FindUserAsync(string Username) {

            var user = await _dbContext.users.Include(u => u.Role).FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
            {

                return null;

            }
            else {

                return user;
            
            }

        }

        public async Task<RefreshToken?> GetRefreshToken(Guid token) {

            var refreshToken = await _dbContext.refreshTokens.Include(r => r.User).ThenInclude(u => u.Role).FirstOrDefaultAsync(x=> x.refreshToken == token);

            return refreshToken;
                
        
        
        }


    }
}
