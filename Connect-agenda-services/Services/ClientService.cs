using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using Connect_agenda_models.Models.FilterModels;
using Connect_agenda_services.Services.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_services.Services
{
    public class ClientService
    {

        private readonly IAdrressRepository _adrressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly IProfissinalServiceRepository _profissinalServiceRepository;
        private readonly IRoleUserCompanyRepository _roleUserCompanyRepository;
        private readonly IUserPlanCardRepository _userPlanCardRepository;

        public ClientService(IAdrressRepository adrressRepository, IUserRepository userRepository, IUserCompanyRepository userCompanyRepository, IProfissinalServiceRepository profissinalServiceRepository, IRoleUserCompanyRepository roleUserCompanyRepository, IUserPlanCardRepository userPlanCardRepository)
        {
            _adrressRepository = adrressRepository;
            _userRepository = userRepository;
            _userCompanyRepository = userCompanyRepository;
            _profissinalServiceRepository = profissinalServiceRepository;
            _roleUserCompanyRepository = roleUserCompanyRepository;
            _userPlanCardRepository = userPlanCardRepository;
        }

        public async Task<List<UserCompanyModel>> getAll(UserCompanyFilterModel filter, string companyId)
        {
            try
            {
                filter.CompanyId = companyId;

                var clients = await _userCompanyRepository.GetAll(filter);

                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> CreateCliente(ClientAddModel clientAdd, string createUserId, string companyId)
        {
            try
            {
                var clientAddres = await CreateClientAddres(clientAdd, createUserId);

                var profissionalUser = await CreateClientUser(clientAdd, clientAddres.Id, createUserId);

                var profissionalUserCompany = await CreateClientUserCompany(profissionalUser.Id, createUserId, companyId);

                var profissionalRole = await CreateClientRoleUserCompany(clientAdd, createUserId, profissionalUserCompany.Id);

                var planCards = await CreateClientPlanCards(clientAdd, createUserId, profissionalUser.Id);

                return "Cliente Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AddresModel> CreateClientAddres(ClientAddModel client, string createUserId)
        {
            try
            {
                ClientAddres clientAddres = client.ClientAddres;

                AddresModel addres = new AddresModel();

                addres.Name = clientAddres.Name;
                addres.Street = clientAddres.Street;
                addres.Neighborhood = clientAddres.Neighborhood;
                addres.Number = clientAddres.Number;
                addres.City = clientAddres.City;
                addres.ZipCode = clientAddres.ZipCode;
                addres.State = clientAddres.State;
                addres.Country = clientAddres.Country;
                addres.Observation = clientAddres.Observation;
                addres.IsActive = true;
                addres.UserUpdateId = createUserId;
                addres.UpdateDate = DateTime.Now;
                addres.UserCreateId = createUserId;
                addres.CreateDate = DateTime.Now;

                await _adrressRepository.Post(addres);

                return addres;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> CreateClientUser(ClientAddModel profissional, string addressId, string createUserId)
        {
            try
            {
                Client profissionalUser = profissional.ClientData;

                UserModel user = new UserModel();

                user.Name = profissionalUser.Name;
                user.SocialName = profissionalUser.SocialName;
                user.Email = profissionalUser.Email;

                //Pensar em um metodo que envia e-mail para criar a senha dps
                user.Password = profissionalUser.Password?.Encrypt();

                user.Gender = profissionalUser.Gender;
                user.Phone = profissionalUser.Phone;
                user.Cpf = profissionalUser.Cpf;
                user.Rg = profissionalUser.Rg;
                user.BirthDate = profissionalUser.BirthDate;
                user.IsAdmin = profissionalUser.IsAdmin;
                user.IsActive = true;
                user.AddresId = addressId;
                user.UserUpdateId = createUserId;
                user.UpdateDate = DateTime.Now;
                user.UserCreateId = createUserId;
                user.CreateDate = DateTime.Now;

                await _userRepository.Post(user);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserCompanyModel> CreateClientUserCompany(string userId, string createUserId, string companyId)
        {
            try
            {
                UserCompanyModel userCompany = new UserCompanyModel();

                userCompany.UserId = userId;
                userCompany.CompanyId = companyId;
                userCompany.IsActive = true;
                userCompany.UserUpdateId = createUserId;
                userCompany.UpdateDate = DateTime.Now;
                userCompany.UserCreateId = createUserId;
                userCompany.CreateDate = DateTime.Now;

                await _userCompanyRepository.Add(userCompany);

                return userCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoleUserCompanyModel> CreateClientRoleUserCompany(ClientAddModel profissional, string createUserId, string userCompanyId)
        {
            try
            {
                RoleUserCompanyModel roleUserCompany = new RoleUserCompanyModel();

                roleUserCompany.Name = "Cliente";
                roleUserCompany.RoleId = "Cliente";
                roleUserCompany.UserCompanyId = userCompanyId;
                roleUserCompany.WorksDays = null;
                roleUserCompany.IsActive = true;
                roleUserCompany.UpdateDate = DateTime.Now;
                roleUserCompany.UserUpdateId = createUserId;
                roleUserCompany.CreateDate = DateTime.Now;
                roleUserCompany.UserCreateId = createUserId;

                await _roleUserCompanyRepository.Post(roleUserCompany);

                return roleUserCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserPlanCardModel>> CreateClientPlanCards(ClientAddModel profissional, string createUserId, string userId)
        {
            try
            {
                List<UserPlanCardModel> planosDeSaude = new List<UserPlanCardModel>();

                for (int i = 0; i < profissional.ClientPlans?.Count; i++)
                {
                    UserPlanCardModel planCard = new UserPlanCardModel();

                    var planCardQueue = profissional.ClientPlans[i];

                    planCard.IdPlanCard = planCardQueue.IdPlanCard;
                    planCard.IdUser = userId;
                    planCard.PlanCardNumber = planCardQueue.PlanCardNumber;
                    planCard.IsActive = true;
                    planCard.UserUpdateId = createUserId;
                    planCard.UpdatedAt = DateTime.Now;
                    planCard.UserCreatedId = createUserId;
                    planCard.CreatedAt = DateTime.Now;

                    planosDeSaude.Add(planCard);

                    await _userPlanCardRepository.Post(planCard);
                }

                return planosDeSaude;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
