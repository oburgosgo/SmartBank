using Auth.API.Interfaces;
using Auth.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authManager;
        public AuthController(IAuth authManager) {
            this._authManager = authManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {

            var isUserLogged =await this._authManager.Login(request);
            return Ok(isUserLogged);
        }
    }
}
