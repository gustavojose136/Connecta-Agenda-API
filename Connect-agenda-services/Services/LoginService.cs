using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models.FilterModels;
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
        private readonly IUserCompanyRepository _userCompanyRepository;

        public LoginService(IUserRepository userRepository, TokenService tokenService, IUserCompanyRepository userCompanyRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _userCompanyRepository = userCompanyRepository;
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

                var userCompany = await _userCompanyRepository.GetByUserId(user.Id);

                return _tokenService.GenerateToken(user.Id, user.Name, userCompany.Id);
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
