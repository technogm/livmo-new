using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IAdminRepository
    {
        public Task<Admin> GetAdminDetailsAsync(string id);
        public Task PutAdminAsync(string id, Admin entity);
        public IEnumerable<Admin> GetAllAdminsAsync();
        public Task<Admin> FindByEmail(string mail);
        public Task<string> Delete(Admin entity);
    }
}
