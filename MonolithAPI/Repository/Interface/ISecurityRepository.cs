using Microsoft.AspNetCore.Identity;
using MonolithAPI.Models;

namespace MonolithAPI.Repository.Interface
{
    public interface ISecurityRepository
    {
        public Task AddUserAsync(User user);

        public Task AddRefreshToken(RefreshToken refreshToken);

        public Task RemoveRefreshToken(Guid token);


        public Task<User?> FindUserAsync(string Username, string HashedPassword, PasswordHasher<string> passwordHasher);


        public Task<User?> FindUserAsync(String Username);

        public Role? GetRole(string RoleName);

        public Task<RefreshToken?> GetRefreshToken(Guid token);

        




    }
}
