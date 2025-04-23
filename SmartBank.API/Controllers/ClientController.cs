using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SmartBank.Application.DTOs;
using SmartBank.Application.Interfaces;

namespace SmartBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetClients();

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _clientService.GetClientById(id);

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
        {
            var isClientAdded =await  _clientService.AddClient(request);

            return Ok(isClientAdded);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientById(Guid id)
        {
            var isClientDeleted = await _clientService.DeleteClientById(id);

            return Ok(isClientDeleted);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] UpdateClientRequest request)
        {

            var isClientUpdated = await this._clientService.UpdateClient(id,request);

            return Ok(isClientUpdated);
        }
    }
}
