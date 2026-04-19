using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MonolithAPI.DTO;
using MonolithAPI.Models;
using MonolithAPI.Repository.Implementation;
using MonolithAPI.Repository.Interface;
using MonolithAPI.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MonolithAPI.Services.Implementation
{
    public class AuthService:IAuthService
    {

        private ISecurityRepository _repo;
        private IConfiguration _config;
        private IMapper _mapper;
        public AuthService(ISecurityRepository repo, IConfiguration config, IMapper mapper)
        {

            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        public async Task DeleteRefreshTokenAsync(Guid token)
        {
            await _repo.RemoveRefreshToken(token);
        }

        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>() { 
              new Claim(ClaimTypes.Name,user.Username),
              new Claim(ClaimTypes.Role,user.Role.RoleName)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWTSettings").GetValue<string>("SymmetricKey")!));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var tokendescriptor = new JwtSecurityToken(
                      issuer:_config.GetSection("JWTSettings").GetValue<string>("Issuer"),
                      audience: _config.GetSection("JWTSettings").GetValue<string>("Audience"),
                      claims: claims,
                      signingCredentials: cred,
                      expires: DateTime.UtcNow.AddMinutes(3)
            );

            var actualToken = new JwtSecurityTokenHandler().WriteToken(tokendescriptor);
            return actualToken.ToString();

        }

        public async Task<RefreshToken> GenerateRefreshToken(User user)
        {

            var userRefreshToken = new RefreshToken();
            userRefreshToken.User = user;
            
            await _repo.AddRefreshToken(userRefreshToken);

            return userRefreshToken;
        }

        public async Task<User?> GetUserAsync(UserDTO user)
        {
            var passwordHasher = new PasswordHasher<string>();

            

            var foundUser = await _repo.FindUserAsync(user.Username,user.Password,passwordHasher);

            return foundUser;
        }

        public async Task<bool> RegisterUserAsync(UserDTO userDTO)
        {
            var foundUser = await _repo.FindUserAsync(userDTO.Username);
            if (foundUser != null)
            {

                return false;
            }
            else {

                 User user  =  _mapper.Map<User>(userDTO);

                 var role = _repo.GetRole("Normal");

                 user.Role = role!;

                 await _repo.AddUserAsync(user);
                return true;
            }
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(Guid refreshToken) { 
        
             var foundToken = await _repo.GetRefreshToken(refreshToken);

             return foundToken; 
        
        
        
        
        }
    }
}
