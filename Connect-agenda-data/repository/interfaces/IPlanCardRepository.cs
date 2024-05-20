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
    public interface IPlanCardRepository
    {
        public Task<PlanCardExitModel> GetAll(PlanCardFilterModel? filter);
        public Task<PlanCardModel> GetById(string id);
        public Task<PlanCardModel> Post(PlanCardModel planCard);
        public Task<PlanCardModel> Update(PlanCardModel planCard);
        public Task<PlanCardModel> Delete(PlanCardModel planCard);
    }
}
