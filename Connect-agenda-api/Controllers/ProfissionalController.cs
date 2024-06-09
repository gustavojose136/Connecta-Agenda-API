
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
    public class ProfissionalController : ControllerBase
    {
        private readonly ProfissionalService _profissionalService;

        public ProfissionalController(ProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        [HttpPost]
        public async Task<IActionResult> PostProfissional([FromBody]ProfissinalAddModel profissinalAdd)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);
                var companyId = User.FindFirstValue(ClaimTypes.Surname);

                return Ok(await _profissionalService.CreateProfissional(profissinalAdd, userId, companyId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
