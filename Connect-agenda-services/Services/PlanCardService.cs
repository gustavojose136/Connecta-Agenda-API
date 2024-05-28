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
    public class PlanCardService
    {
        private readonly IPlanCardRepository _planCardRepostory;
        public PlanCardService(IPlanCardRepository planCardRepostory) 
        {
            _planCardRepostory = planCardRepostory;
        }


        public async Task<PlanCardExitModel> GetAllPlanCards(PlanCardFilterModel filter)
        {
            try
            {
                return await _planCardRepostory.GetAll(filter);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanCardModel> CreatePlanCard(PlanCardModel planCard, string userId)
        {
            try
            {
                if(string.IsNullOrEmpty(planCard.Name)) throw new Exception("O Nome do plano é obrigatório");

                PlanCardModel NewPlancCard = new PlanCardModel();
                
                NewPlancCard = planCard;

                NewPlancCard.Id = Guid.NewGuid().ToString();
                NewPlancCard.IsActive = true;
                NewPlancCard.UserCreateId = userId;
                NewPlancCard.CreateDate = DateTime.Now;

                await _planCardRepostory.Post(NewPlancCard);

                return (NewPlancCard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanCardModel> UpdatePlanCard(PlanCardModel planCard, string userId)
        {
            try
            {
                if(string.IsNullOrEmpty(planCard.Name)) throw new Exception("O Nome do plano é obrigatório");

                var existPlanCard = await _planCardRepostory.GetById(planCard.Id);

                if(existPlanCard == null) throw new Exception("Plano não encontrado");

                
                existPlanCard.Name = planCard.Name;
                existPlanCard.Description = planCard.Description;
                existPlanCard.IsActive = planCard.IsActive;

                existPlanCard.UserUpdateId = userId;
                existPlanCard.UpdateDate = DateTime.Now;

                await _planCardRepostory.Update(existPlanCard);

                return (existPlanCard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
