using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository.interfaces
{
    public interface IProfissinalServiceRepository
    {
        public Task<List<ProfissionalServiceModel>> GetAll();
        public Task<ProfissionalServiceModel> GetById(string profissionalId);
        public Task<ProfissionalServiceModel> Post(ProfissionalServiceModel profissionalService);
    }
}
