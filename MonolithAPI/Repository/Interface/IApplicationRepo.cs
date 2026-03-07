using MonolithAPI.Models;

namespace MonolithAPI.Repository.Interface
{
    public interface IApplicationRepo
    {
        public Task AddUserAsync(User user);

        public Task AddRefreshToken(RefreshToken refreshToken);

        public Task RemoveRefreshToken(Guid token);


        public Task<User?> FindUserAsync(string Username, string HashedPassword);

        public Role? GetRole(string RoleName);

        




    }
}
