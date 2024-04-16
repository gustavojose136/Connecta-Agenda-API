using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_services.Services
{
    public class LoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public LoginService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        //Metodo que faz login
        public async Task<TokenModel> Login(LoginModel login)
        {
            try
            {
                TokenModel tokenM = new TokenModel();

                var user = await _userRepository.Login(login.Email, login.Password);

                //exeption
                if (user == null) return BadRequest("Usuário ou senha inválidos");

                //return _tokenService.GenerateToken(user.Id, user.Name);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private TokenModel BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}
