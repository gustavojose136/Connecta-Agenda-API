using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
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

        public async Task<UserExitModel> GetAllUsers (UserFilterModel filter, int pageNumber, int pageItems)
        {
            try
            {
                pageItems = pageItems > 100 ? 100 : pageItems;
             
                var users = await _userRepository.GetAll(filter, pageNumber, pageItems);

                return users;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
