using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_services.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();

                var createdUser = await _userRepository.Post(user);
                
                return createdUser;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
