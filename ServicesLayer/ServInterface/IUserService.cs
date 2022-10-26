using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IUserService
    {
        public IEnumerable<Users> GetAllUsers();
        public Task AddUserAsync(Users Users);
        public Task DeleteUserAsync(string id);
        public IEnumerable<Users> GetAllUsersDetails();
        public Task UpdateUserAsync(string id, Users Users);
        public Task<Users> GetUserByIdAsync(string id);
        public Task<Users> GetById(string id);
        public Task<Users> FindByMail(string mail);
        public List<Guid> GetPhotoIdOfUser(string UserId);
        public List<Guid> GetCINidOfUser(string UserId);
        public List<Guid> GetCADTransportidOfUser(string UserId);
        public List<Guid> GetRNEidOfUser(string UserId);
        public List<Guid> GetLicenceidOfUser(string UserId);
        public Task<bool> GetUserEmailValidation(string email);


    }
}
