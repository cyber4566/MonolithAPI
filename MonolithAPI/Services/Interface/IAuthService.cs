using MonolithAPI.DTO;
using MonolithAPI.Models;

namespace MonolithAPI.Services.Interface
{
    public interface IAuthService
    {
        public Task<User?> GetUserAsync(UserDTO user);

        public string GenerateAccessToken(User user);

        public Task<RefreshToken> GenerateRefreshToken(User user);

        public Task DeleteRefreshTokenAsync(Guid token);

        public Task<bool> RegisterUserAsync(UserDTO user);

        public Task<RefreshToken?> GetRefreshTokenAsync(Guid token);
    }
}
