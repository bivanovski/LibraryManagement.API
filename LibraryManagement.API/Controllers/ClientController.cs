using LibraryManagement.Service.DTOs;
using LibraryManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.getAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clientService.getClientByIdAsync(id);
            return result == null ? NotFound("Client not found.") : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDTO dto)
        {
            var result = await _clientService.createClientAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientDTO dto)
        {
            var result = await _clientService.UpdateClientAsync(id, dto);
            return result == null ? NotFound("Client not found.") : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _clientService.DeleteClientAsync(id);
            return success ? NoContent() : NotFound("Client not found.");
        }
    }
}
