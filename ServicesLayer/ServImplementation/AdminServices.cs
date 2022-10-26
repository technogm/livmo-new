using DataLayer.Models;
using RepositoryLayer.RepInterface;
using ServicesLayer.ServInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServImplementation
{
    public class AdminServices : IAdminService
    {
        readonly private IGenericRepository<Admin> GenericRepo;
        readonly private IAdminRepository AdminRepo;
        public AdminServices(IGenericRepository<Admin> _GenericRepo, IAdminRepository _CompanyRepo)
        {
            GenericRepo = _GenericRepo;
            AdminRepo = _CompanyRepo;
        }
        public Task AddAdminAsync(Admin Admin)
        {
            return GenericRepo.InsertAsync(Admin);
        }

        public Task DeleteAdminAsync(Admin Admin)
        {
            return GenericRepo.DeleteAsync(Admin.Id);
        }

        public Task<Admin> GetAdminById(string id)
        {
            return AdminRepo.GetAdminDetailsAsync(id);

        }

        public IList<Admin> GetAllAdmins()
        {
             return AdminRepo.GetAllAdminsAsync().ToList();
        }
            public Task UpdateAdminAsync(Admin Admin)
        {
            return GenericRepo.PutAsync(Admin.Id, Admin);
        }
    }
}
