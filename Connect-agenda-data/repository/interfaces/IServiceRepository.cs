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
    public interface IServiceRepository
    {
        public Task<ServiceExitModel> GetAll(ServiceFilterModel filter);
        public Task<ServiceModel> Post(ServiceModel service);
        public Task<ServiceModel> Update(ServiceModel service);
        public Task<ServiceModel> Inactive(string id);
        public Task<ServiceModel> Delete(ServiceModel service);
    }
}
