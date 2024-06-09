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

        public ProfissionalService(IAdrressRepository adrressRepository, IUserRepository userRepository, IUserCompanyRepository userCompanyRepository, IProfissinalServiceRepository profissinalServiceRepository)
        {
            _adrressRepository = adrressRepository;
            _userRepository = userRepository;
            _userCompanyRepository = userCompanyRepository;
            _profissinalServiceRepository = profissinalServiceRepository;
        }

        public async Task<bool> CreateProfissional(ProfissinalAddModel profissinalAdd, string createUserId)
        {
            try
            {
                var profissionalAddres = await CreateProfissionalAddres(profissinalAdd, createUserId);

                var profissionalUser = await CreateProfissionalUser(profissinalAdd, profissionalAddres.Id, createUserId);

                var profissionalUserCompany = await CreateProfissionalUser(profissinalAdd, profissionalUser.Id, createUserId);

                return true;
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
    }
}
