using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Connect_agenda_data.repository
{
    public class UserCompanyRepository : IUserCompanyRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public UserCompanyRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<List<UserCompanyModel>> GetAll(UserCompanyFilterModel filter)
        {
            try
            {
                var query = _dBContext.UserCompany.AsQueryable();

                if (!string.IsNullOrEmpty(filter.UserId))
                {
                    query = query.Where(x => x.UserId == filter.UserId);
                }

                if (!string.IsNullOrEmpty(filter.CompanyId))
                {
                    query = query.Where(x => x.CompanyId == filter.CompanyId);
                }

                if (filter.IsActive.HasValue)
                {
                    query = query.Where(x => x.IsActive == filter.IsActive);
                }

                query = query   
                        .Include(x => x.User);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCompanyModel> GetById(string id)
        {
            try
            {
                return await _dBContext.UserCompany
                                                .Include(x => x.User)
                                                .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCompanyModel> GetByUserId(string userId)
        {
            try
            {
                return await _dBContext.UserCompany
                                                .FirstOrDefaultAsync(x => x.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCompanyModel> Add(UserCompanyModel userCompany)
        {
            try
            {
                await _dBContext.UserCompany.AddAsync(userCompany);
                await _dBContext.SaveChangesAsync();

                return userCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCompanyModel> Update(UserCompanyModel userCompany)
        {
            try
            {
                _dBContext.UserCompany.Update(userCompany);
                await _dBContext.SaveChangesAsync();

                return userCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCompanyModel> Inactive(string id)
        {
            try
            {
                var userCompany = await _dBContext.UserCompany.FirstOrDefaultAsync(x => x.Id == id);

                if(userCompany == null)
                    throw new Exception("UserCompany not found");

                userCompany.IsActive = false;

                await _dBContext.SaveChangesAsync();
                return userCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(string id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
