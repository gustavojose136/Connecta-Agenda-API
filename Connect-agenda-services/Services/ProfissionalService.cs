using Connect_agenda_data.repository.interfaces;
using Connect_agenda_models.Models;
using Connect_agenda_models.Models.AddModels;
using Connect_agenda_services.Services.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_services.Services
{
    public class ProfissionalService
    {
        private readonly IAdrressRepository _adrressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly IProfissinalServiceRepository _profissinalServiceRepository;
        private readonly IRoleUserCompanyRepository _roleUserCompanyRepository;

        public ProfissionalService(IAdrressRepository adrressRepository, IUserRepository userRepository, IUserCompanyRepository userCompanyRepository, IProfissinalServiceRepository profissinalServiceRepository, IRoleUserCompanyRepository roleUserCompanyRepository)
        {
            _adrressRepository = adrressRepository;
            _userRepository = userRepository;
            _userCompanyRepository = userCompanyRepository;
            _profissinalServiceRepository = profissinalServiceRepository;
            _roleUserCompanyRepository = roleUserCompanyRepository;
        }

        public async Task<string> CreateProfissional(ProfissinalAddModel profissinalAdd, string createUserId, string companyId)
        {
            try
            {
                var profissionalAddres = await CreateProfissionalAddres(profissinalAdd, createUserId);

                var profissionalUser = await CreateProfissionalUser(profissinalAdd, profissionalAddres.Id, createUserId);

                var profissionalUserCompany = await CreateProfissionalUserCompany(profissinalAdd, profissionalUser.Id, createUserId, companyId);

                var profissionalRole = await CreateProfissionalRoleUserCompany(profissinalAdd, createUserId, profissionalUserCompany.Id);

                var services = await CreateProfissionalServices(profissinalAdd, createUserId, profissionalUserCompany.Id);

                return "Profissional Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AddresModel> CreateProfissionalAddres(ProfissinalAddModel profissional, string createUserId)
        {
            try
            {
                ProfissionalAddres profissionalAddres = profissional.ProfissionalAddres;

                AddresModel addres = new AddresModel();

                addres.Name = profissionalAddres.Name;
                addres.Street = profissionalAddres.Street;
                addres.Neighborhood = profissionalAddres.Neighborhood;
                addres.Number = profissionalAddres.Number;
                addres.City = profissionalAddres.City;
                addres.ZipCode = profissionalAddres.ZipCode;
                addres.State = profissionalAddres.State;
                addres.Country = profissionalAddres.Country;
                addres.Observation = profissionalAddres.Observation;
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

        public async Task<UserModel> CreateProfissionalUser(ProfissinalAddModel profissional, string addressId, string createUserId)
        {
            try
            {
                Profissional profissionalUser = profissional.ProfissionalData;

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
                user.IsAdmin = false;
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

        public async Task<UserCompanyModel> CreateProfissionalUserCompany(ProfissinalAddModel profissional, string userId, string createUserId, string companyId)
        {
            try
            {
                Profissional profissionalUser = profissional.ProfissionalData;

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

        public async Task<List<ProfissionalServiceModel>> CreateProfissionalServices(ProfissinalAddModel profissional, string createUserId, string profissionalId)
        {
            try
            {
                List<ProfissionalServiceModel> servicos = new List<ProfissionalServiceModel>();

                for (int i = 0; i < profissional.ProfissionalServices?.Count; i++)
                {
                    ProfissionalServiceModel profissionalService = new ProfissionalServiceModel();

                    var serviceQueue = profissional.ProfissionalServices[i];

                    profissionalService.ProfissionalId = profissionalId;
                    profissionalService.ServiceId = serviceQueue.ServiceId;
                    profissionalService.Price = serviceQueue.Price;
                    profissionalService.Description = serviceQueue.Description;
                    profissionalService.Duration = serviceQueue.Duration;
                    profissionalService.IsActive = true;
                    profissionalService.UserUpdateId = createUserId;
                    profissionalService.UpdateDate = DateTime.Now;
                    profissionalService.UserCreateId = createUserId;
                    profissionalService.CreateDate = DateTime.Now;

                    servicos.Add(profissionalService);

                    await _profissinalServiceRepository.Post(profissionalService);
                }

                return servicos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoleUserCompanyModel> CreateProfissionalRoleUserCompany(ProfissinalAddModel profissional, string createUserId, string userCompanyId)
        {
            try
            {
                RoleUserCompanyModel roleUserCompany = new RoleUserCompanyModel();

                roleUserCompany.Name = "Profissional";
                roleUserCompany.RoleId = "Profissional";
                roleUserCompany.UserCompanyId = userCompanyId;
                roleUserCompany.WorksDays = profissional.ProfissionalData.WorksDays;
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
    }
}
