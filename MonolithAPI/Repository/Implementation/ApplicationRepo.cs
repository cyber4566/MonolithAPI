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


        


        public void AddRefreshToken(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindUserAsync(string Username, string HashedPassword)
        {
            var user = await _dbContext.users.FirstOrDefaultAsync(x => x.Username == Username & x.HashedPassword == HashedPassword);
            return user;
        }




        public void RemoveRefreshToken(Guid token)
        {
            throw new NotImplementedException();
        }


    }
}
