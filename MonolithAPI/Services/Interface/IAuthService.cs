using MonolithAPI.DTO;
using MonolithAPI.Models;

namespace MonolithAPI.Services.Interface
{
    public interface IAuthService
    {
        public Task<User?> ValidateUser(UserDTO user);

        public string GenerateAccessToken(User user);

        public string GenerateRefreshToken();

        public void DeleteRefreshToken(Guid token);
    }
}
