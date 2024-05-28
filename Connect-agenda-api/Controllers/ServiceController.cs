using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using Connect_agenda_models.Models.FilterModels;
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
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ServiceFilterModel filter)
        {
            try
            {
                var result = await _serviceService.GetAll(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceAddModel service)
        {
            try
            {
                string companyId = "EMPRESATESTE";
                string userId = User.FindFirstValue(ClaimTypes.Name);

                var result = await _serviceService.Post(service, companyId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ServiceModel service)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);

                var result = await _serviceService.Update(service, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("inactive/")]
        public async Task<IActionResult> Inactive([FromQuery]string serviceId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);

                var result = await _serviceService.Inactive(serviceId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
