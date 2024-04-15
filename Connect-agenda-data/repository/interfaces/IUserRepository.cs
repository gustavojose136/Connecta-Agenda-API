using Connect_agenda_models.Models;
using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> Login(string userEmail, string password);
        Task<UserExitModel> GetAll(UserFilterModel? filter, int pageNumber, int pageItems);
        Task<UserModel> Post(UserModel model);
        Task<UserModel> Update(UserModel model);
        Task<UserModel> Inactive(string id);
        Task<UserModel> Delete(string id);
    }
}
