using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonolithAPI.DTO;
using MonolithAPI.Models;
using MonolithAPI.Services.Interface;

namespace MonolithAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthApiController : Controller
    {

        private IAuthService _authService;

        public AuthApiController(IAuthService authService) { 
        
              this._authService = authService;
        
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserDTO user)
        {
            var foundUser = await _authService.GetUserAsync(user);

            if (foundUser == null) { return BadRequest("Username and/or password is invalid"); }
            else {

                var accessToken = _authService.GenerateAccessToken(foundUser);
                var refreshToken = await _authService.GenerateRefreshToken(foundUser);

                var responseDTO = new TokenResponseDTO { 
                
                       AccessToken = accessToken,
                       RefreshToken = refreshToken.refreshToken
                };

                return Ok(responseDTO);
            }


                
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserDTO user) {

            bool registered = await _authService.RegisterUserAsync(user);

            if (registered)
            {

                return Ok("User registered successfully. You can login now");
            }
            else {

                return BadRequest("User registration failed. User possibly already exists in the system");
            
            }

                
        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<ActionResult> Refresh(Guid refreshToken) { 
        
             RefreshToken? foundRefreshToken = await _authService.GetRefreshTokenAsync(refreshToken);

             if (foundRefreshToken != null) {


                if (foundRefreshToken.ExpireAt > DateTime.Now)
                {

                    User user = foundRefreshToken.User;

                    await _authService.DeleteRefreshTokenAsync(foundRefreshToken.refreshToken);

                    var new_accessToken = _authService.GenerateAccessToken(user);
                    var new_refreshToken = await _authService.GenerateRefreshToken(user);

                    var responseDTO = new TokenResponseDTO
                    {

                        AccessToken = new_accessToken,
                        RefreshToken = new_refreshToken.refreshToken
                    };

                    return Ok(responseDTO);

                }
                else {

                    return BadRequest("Refresh token expired");
                }
                

             }

            else
            {
                return Unauthorized("Invalid refresh token");
            }




        }



        [HttpGet]
        [Authorize(Roles ="Normal")]
        [Route("test-auth")]
        public ActionResult test() {

            return Ok();
        
        }


    }
}
