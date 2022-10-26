using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IAdminService
    {
        public Task AddAdminAsync(Admin Admin);
        public IList<Admin> GetAllAdmins();
        public Task UpdateAdminAsync(Admin Admin);
        public Task<Admin> GetAdminById(string id);
        public Task DeleteAdminAsync(Admin Admin);
    }
}
