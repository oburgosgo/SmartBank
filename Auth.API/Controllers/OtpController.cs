using Auth.API.Interfaces;
using Auth.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController: ControllerBase
    {

        private readonly IOtpProvider _provider;
        public OtpController(IOtpProvider provider)
        {
            this._provider = provider;
        }
        [HttpPost]
        public async Task<IActionResult> GenerateOtp([FromBody] GenerateOtpRequest request)
        {

            var result = await this._provider.GenerateOtp(request);
            return Ok(result);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetOtp(string key)
        {

            var result = await this._provider.GetOtp(key);

            return Ok(result);
        }
        [HttpDelete("{key}")]
        public async Task<IActionResult> RemoveOtp(string key)
        {
            await this._provider.RemoveOtp(key);

            return Ok();
        }
        
    }
}
