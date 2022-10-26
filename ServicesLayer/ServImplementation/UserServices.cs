using DataLayer.Models;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class UserServices : IUserService
    {
        readonly private IGenericRepository<Users> GenericRepo;
        readonly private IUserRepository UserRepo;
        public UserServices(IGenericRepository<Users> _GenericRepo, IUserRepository _CompanyRepo)
        {
            GenericRepo = _GenericRepo;
            UserRepo = _CompanyRepo;
        }
        public Task DeleteUserAsync(string id)
        {
            return GenericRepo.DeleteAsync(id);
        }

        public Task<Users> FindByMail(string mail)
        {
            return UserRepo.FindByEmail(mail);
        }

        public IEnumerable<Users> GetAllUsersDetails()
        {
            return UserRepo.GetAllUserAsync();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return GenericRepo.GetAll();
        }

        public Task<Users> GetById(string id)
        {
            return UserRepo.GetUserDetailsAsync(id);
        }

        public Task<Users> GetUserByIdAsync(string id)
        {
            return GenericRepo.GetByIdAsync(id);
        }

        public Task AddUserAsync(Users Users)
        {
            return GenericRepo.InsertAsync(Users);
        }

        public Task UpdateUserAsync(string id, Users Users)
        {
            return UserRepo.PutUserAsync(id, Users);

        }

        public List<Guid> GetPhotoIdOfUser(string UserId)
        {
            return UserRepo.GetPhotoIdOfUser(UserId);
        }

        public List<Guid> GetCINidOfUser(string UserId)
        {
            return UserRepo.GetCINidOfUser(UserId);
        }

        public List<Guid> GetCADTransportidOfUser(string UserId)
        {
            return UserRepo.GetCADTransportidOfUser(UserId);
        }

        public List<Guid> GetRNEidOfUser(string UserId)
        {
            return UserRepo.GetRNEidOfUser(UserId);
        }

        public List<Guid> GetLicenceidOfUser(string UserId)
        {
            return UserRepo.GetLicenceidOfUser(UserId);
        }

        public Task<bool> GetUserEmailValidation(string email)
        {
            return UserRepo.GetUserEmailValidation(email);
        }
    }
}
