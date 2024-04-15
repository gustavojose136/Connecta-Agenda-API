using Connect_agenda_api.Encryption;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.FilterModels;
using Connect_agenda_services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connect_agenda_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery]UserFilterModel filter, int pageNumber, int pageItems)
        {
            try
            {
                var users = await _userService.GetAllUsers(filter, pageNumber, pageItems);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            try
            {
                user.Password = user.Password.Encrypt();

                var userC = await _userService.CreateUser(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
