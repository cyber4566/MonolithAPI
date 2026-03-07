using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonolithAPI.DTO;
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
                var refreshToken = await _authService.GenerateRefreshToken();

                var responseDTO = new TokenResponseDTO { 
                
                       AccessToken = accessToken,
                       RefreshToken = refreshToken
                };

                return Ok(responseDTO);
            }


                
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserDTO user) {

            var registered = await _authService.RegisterUserAsync(user);

            if (registered)
            {

                return Ok("User registered successfully. You can login now");
            }
            else {

                return BadRequest("User registration failed. User possibly already exists in the system");
            
            }

                
        }

        [HttpGet]
        [Authorize()]
        [Route("test-auth")]
        public ActionResult test() {

            return Ok();
        
        }


    }
}
