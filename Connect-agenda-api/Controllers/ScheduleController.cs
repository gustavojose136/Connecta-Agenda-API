using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using Connect_agenda_services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Connect_agenda_models.Models.FilterModels;

namespace Connect_agenda_api.Controllers
{
    [Route("api/[controller]")]
    // [Authorize]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderFilterModel filter)
        {
            try
            {
                // var companyId = User.FindFirstValue(ClaimTypes.Surname);
                var companyId = "EMPRESATESTE";

                return Ok(await _scheduleService.getAll(filter, companyId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderAddModel orderAdd)
        {
            try
            {
                // var userId = User.FindFirstValue(ClaimTypes.Name);
                // var companyId = User.FindFirstValue(ClaimTypes.Surname);

                var userId = "eaafdb55-ad79-4dfe-88cf-0b3739158753";
                var companyId = "EMPRESATESTE";

                return Ok(await _scheduleService.CreateSchedule(orderAdd, companyId, userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
