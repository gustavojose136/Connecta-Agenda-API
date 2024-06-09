using Connect_agenda_data.data;
using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_data.repository
{
    public class UserPlanCardRepository : IUserPlanCardRepository
    {
        private readonly ConnectAgendaContext _dBContext;

        public UserPlanCardRepository(ConnectAgendaContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<UserPlanCardModel> Post(UserPlanCardModel userPlanCard)
        {
            try
            {
                await _dBContext.UserPlanCard.AddAsync(userPlanCard);
                await _dBContext.SaveChangesAsync();

                return userPlanCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
