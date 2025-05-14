using Auth.API.Interfaces;
using Auth.API.Models;
using Microsoft.AspNetCore.Mvc;
using SmartBank.Shared.API.Reponse;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _userManager;
        public UserController(IUser userManager) { 
            this._userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel request)
        {

            
            var result =await _userManager.Register(request);

            if (result.Succeeded)
            {
                return Ok(new APIResponse<object>
                {
                    Success = true,
                    Data = null,
                    Message = "User created succesfully"
                });
            }
            else
            {
                return BadRequest(new APIResponse<object>
                {
                    Success = false,
                    Data = null,
                    Message = "User creation failed",
                    Errors = result.Errors.Select(x => x.Description).ToList()
                });
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = this._userManager.GetUsers();

            return Ok(users);
        }
    }
}
