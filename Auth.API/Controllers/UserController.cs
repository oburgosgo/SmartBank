using Auth.API.Interfaces;
using Auth.API.Models;
using Microsoft.AspNetCore.Mvc;

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

            var isUserCreated =await _userManager.Register(request);

            return Ok(isUserCreated);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = this._userManager.GetUsers();

            return Ok(users);
        }
    }
}
