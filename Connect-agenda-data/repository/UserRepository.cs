using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public UserRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<UserModel> Login(string userEmail, string password)
        {
            try
            {
                var user = await _dBContext.User.Where(x => x.Email == userEmail && x.Password == password).FirstAsync()    ;
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserExitModel> GetAll(UserFilterModel? filter, int pageNumber, int pageItems)
        {
            try
            {
                UserExitModel exit = new UserExitModel();
                exit.Users = new List<UserModel>();

                var query = _dBContext.User.AsQueryable();

                if (filter?.Id != null)
                    query = query.Where(x => x.Id == filter.Id);

                if (filter?.Name != null)
                    query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Name}%"));

                if (filter?.Email != null)
                    query = query.Where(x => EF.Functions.Like(x.Email, $"%{filter.Email}%"));

                if (filter?.SocialName != null)
                    query = query.Where(x => EF.Functions.Like(x.SocialName, $"%{filter.SocialName}%"));

                if (filter?.Gender != null)
                    query = query.Where(x => x.Gender == filter.Gender);

                if (filter?.Cpf != null)
                    query = query.Where(x => x.Cpf == filter.Cpf);

                if (filter?.Rg != null)
                    query = query.Where(x => x.Rg == filter.Rg);

                if (filter?.IsActive != null)
                    query = query.Where(x => x.IsActive == filter.IsActive);

                if (filter?.IsAdmin != null)
                    query = query.Where(x => x.IsAdmin == filter.IsAdmin);

                query.OrderByDescending(x => x.CreateDate);


                exit.Total = query.Count();
                exit.Users = await query.ToListAsync();

                return exit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> Post(UserModel user)
        {
            try
            {
                await _dBContext.AddAsync(user);
                await _dBContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> Update(UserModel user)
        {
            try
            {
                var ExistUser = await GetAll(new UserFilterModel() { Id = user.Id }, 1 ,1);

                if (ExistUser == null || ExistUser.Total < 1)
                    throw new Exception("Usuário não encontrado");

                _dBContext.Update(user);
                await _dBContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> Inactive(string userId)
        {
            try
            {
                var ExistUser = await GetAll(new UserFilterModel() { Id = userId }, 1, 1);

                if (ExistUser == null || ExistUser.Total < 1)
                    throw new Exception("Usuário não encontrado");

                var user = ExistUser.Users[0];

                user.IsActive = false;

                _dBContext.Update(user);
                await _dBContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> Delete(string id)
        {
            try
            {
                var ExistUser = await GetAll(new UserFilterModel() { Id = id }, 1, 1);

                if (ExistUser == null || ExistUser.Total < 1)
                    throw new Exception("Usuário não encontrado");

                var user = ExistUser.Users[0];

                _dBContext.Remove(user);
                _dBContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
