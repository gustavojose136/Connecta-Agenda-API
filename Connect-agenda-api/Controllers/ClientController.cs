using Connect_agenda_models.Models.AddModels;
using Connect_agenda_services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Connect_agenda_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> PostProfissional([FromBody] ClientAddModel clientAdd)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);
                var companyId = User.FindFirstValue(ClaimTypes.Surname);

                return Ok(await _clientService.CreateCliente(clientAdd, userId, companyId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
