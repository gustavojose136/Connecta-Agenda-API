using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_services.Services
{
    public class ServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUserRepository _userRepository;

        public ServiceService(IServiceRepository serviceRepository, IUserRepository userRepository)
        {
            _serviceRepository = serviceRepository;
            _userRepository = userRepository;
        }

        public async Task<ServiceExitModel> GetAll(ServiceFilterModel filter)
        {
            try
            {
                return await _serviceRepository.GetAll(filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceModel> Post(ServiceAddModel serviceAdd, string companyId, string userId)
        {
            try
            { 
                ServiceModel service = new ServiceModel();
                service.Id = Guid.NewGuid().ToString();
                service.Name = serviceAdd.Name;
                service.Description = serviceAdd.Description;
                service.Price = serviceAdd.Price;
                service.Duration = serviceAdd.Duration;
                service.CompanyId = companyId;
                service.UserCreateId = userId;
                service.CreateDate = DateTime.Now;
                service.UserUpdateId = userId;
                service.UpdateDate = DateTime.Now;
                service.IsActive = true;

                if(serviceAdd.Image != null)
                {

                    service.Image = Convert.FromBase64String(serviceAdd.Image.Split(",")[1]);
                }
                else
                {
                    service.Image = null;
                }

                return await _serviceRepository.Post(service);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceModel> Update(ServiceModel service, string userId)
        {
            try
            {
                service.UserUpdateId = userId;
                service.UpdateDate = DateTime.Now;

                return await _serviceRepository.Update(service);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceModel> Inactive(string id, string userId)
        {
            try
            {
                var service = await _serviceRepository.Inactive(id);
                service.UserUpdateId = userId;
                service.UpdateDate = DateTime.Now;

                return await _serviceRepository.Update(service);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
