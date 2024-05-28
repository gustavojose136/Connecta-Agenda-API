using Connect_agenda_models.Models;
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
    public class PlanCardController : ControllerBase
    {
        private readonly PlanCardService _planCardService;

        public PlanCardController(PlanCardService planCardService)
        {
            _planCardService = planCardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanCards([FromQuery]PlanCardFilterModel? filter)
        {
            try
            {
                var planCards = await _planCardService.GetAllPlanCards(filter);

                return Ok(planCards);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanCard(PlanCardModel planCard)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);

                var planCardC = await _planCardService.CreatePlanCard(planCard, userId);

                return Ok(planCard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlanCard(PlanCardModel planCard)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);

                var planCardU = await _planCardService.UpdatePlanCard(planCard, userId);

                return Ok(planCard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeletePlanCard(int id)
        //{
        //    try
        //    {
        //        var userId = User.FindFirstValue(ClaimTypes.Name);

        //        await _planCardService.DeletePlanCard(id, userId);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
