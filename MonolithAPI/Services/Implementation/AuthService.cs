using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MonolithAPI.DTO;
using MonolithAPI.Models;
using MonolithAPI.Repository.Implementation;
using MonolithAPI.Repository.Interface;
using MonolithAPI.Services.Interface;

namespace MonolithAPI.Services.Implementation
{
    public class AuthService:IAuthService
    {

        private IApplicationRepo _repo;

        public AuthService(IApplicationRepo repo) { 
        
              _repo = repo;
        }

        public void DeleteRefreshToken(Guid token)
        {
            throw new NotImplementedException();
        }

        public string GenerateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> ValidateUser(UserDTO user)
        {
            var passwordHasher = new PasswordHasher<string>();

            string hashedPassword = passwordHasher.HashPassword(user.Username,user.Password);

            var foundUser = await _repo.FindUserAsync(user.Username,hashedPassword);

            return foundUser;
        }
    }
}
