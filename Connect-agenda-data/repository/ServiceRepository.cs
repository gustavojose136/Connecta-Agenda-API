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
    public class ServiceRepository : IServiceRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public ServiceRepository(ConnectAgendaContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<ServiceExitModel> GetAll(ServiceFilterModel filter)
        {
            try
            {
                ServiceExitModel exit = new ServiceExitModel();

                var query = _dBContext.Service.AsQueryable();

                if (filter.Name != null)
                    query = query.Where(x => x.Name.Contains(filter.Name));
                
                if (filter.Description != null)
                    query = query.Where(x => x.Description.Contains(filter.Description));
                
                if (filter.CompanyId != null)
                    query = query.Where(x => x.CompanyId == filter.CompanyId);
                
                if (filter.IsActive != null)
                    query = query.Where(x => x.IsActive == filter.IsActive);
                
                exit.Total = await query.CountAsync();

                query = query
                    .Include(x => x.Company)
                    .Include(x => x.UserCreate);

                exit.Data = await query.ToListAsync();

                return exit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public async Task<ServiceModel> Post(ServiceModel service)
        {
            try
            {
                await _dBContext.Service.AddAsync(service);
                await _dBContext.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceModel> Update(ServiceModel service)
        {
            try
            {
                _dBContext.Service.Update(service);
                await _dBContext.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceModel> Inactive(string id)
        {
            try
            {         
                var service = _dBContext.Service.Where(x => x.Id == id).FirstOrDefault();

                if (service == null)
                    throw new Exception("Serviço não encontrado");

                service.IsActive = false;

                _dBContext.Service.Update(service);
                await _dBContext.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceModel> Delete(ServiceModel service)
        {
            try
            {
                _dBContext.Service.Remove(service);
                await _dBContext.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
