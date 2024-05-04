using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class PlanCardRepository : IPlanCardRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public PlanCardRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<List<PlanCardModel>> GetAll()
        {
            try
            {
                return _dBContext.PlanCard.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanCardModel> GetById(string id)
        {
            try
            {
                return await _dBContext.PlanCard.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanCardModel> Post(PlanCardModel planCard)
        {
            try
            {
                await _dBContext.PlanCard.AddAsync(planCard);
                await _dBContext.SaveChangesAsync();

                return planCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanCardModel> Update(PlanCardModel planCard)
        {
            try
            {
                _dBContext.Update(planCard);
                await _dBContext.SaveChangesAsync();

                return planCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanCardModel> Delete(PlanCardModel planCard)
        {
            try
            {
                _dBContext.Update(planCard);
                await _dBContext.SaveChangesAsync();

                return planCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
