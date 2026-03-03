using MonolithAPI.Models;

namespace MonolithAPI.Repository.Interface
{
    public interface IApplicationRepo
    {
        public bool AddUser(User user);

        public void AddRefreshToken(RefreshToken refreshToken);

        public void RemoveRefreshToken(Guid token);


        public Task<User?> FindUserAsync(string Username, string HashedPassword);

        




    }
}
