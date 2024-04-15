using Connect_agenda_api.Encryption;
using Connect_agenda_models.Models;
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
