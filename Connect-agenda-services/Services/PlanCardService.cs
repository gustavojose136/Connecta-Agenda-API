using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
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


        public async Task<List<PlanCardModel>> GetAllPlanCards()
        {
            try
            {
                return await _planCardRepostory.GetAll();
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
                PlanCardModel NewPlancCard = new PlanCardModel();

                NewPlancCard = planCard;

                NewPlancCard.Id = Guid.NewGuid().ToString();
                NewPlancCard.IsActive = true;
                NewPlancCard.UserCreateId = userId;
                NewPlancCard.CreateDate = new DateTime();

                await _planCardRepostory.Post(NewPlancCard);

                return (NewPlancCard);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
