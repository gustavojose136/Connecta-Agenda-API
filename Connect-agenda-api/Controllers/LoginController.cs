using Connect_agenda_api.Encryption;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.Utils;
using Connect_agenda_services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connect_agenda_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                //login.Password = login.Password.Encrypt();

                var token = await _loginService.Login(login);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
