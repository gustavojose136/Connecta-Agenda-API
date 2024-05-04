using Connect_agenda_models.Models.ExitModels;
using Connect_agenda_models.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface IAdrressRepository
    {
        public Task<AddressExitModel> GetAll(AddressFilterModel filter, int pageNumber, int pageItems);
        public Task<AddressExitModel> Post(AddressFilterModel model);
        public Task<AddressExitModel> Update(AddressFilterModel model);
        public Task<AddressExitModel> Inactive(string id);
        public Task<AddressExitModel> Delxete(string id);
    }
}
