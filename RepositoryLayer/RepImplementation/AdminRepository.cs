using DataLayer.Data;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepImplementation
{
    public class AdminRepository : IAdminRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Admin> _genericRepoAdmin;

        public AdminRepository(ApplicationDbContext dbContext, IGenericRepository<Admin> GenericRepoAdmin)
        {
            _dbContext = dbContext;
            _genericRepoAdmin = GenericRepoAdmin;
        }
        public async Task<string> Delete(Admin entity)
        {
            try
            {

                await _genericRepoAdmin.DeleteAsync(entity.Id);
            }
            catch (Exception)
            {
                return "fail";

            }
            return "success";
        }

        public async Task<Admin> FindByEmail(string mail)
        {
            var user = await _dbContext.Admins.SingleAsync(x => x.Email == mail);
            _dbContext.Entry(user);
            return user;
        }

        public async Task<Admin> GetAdminDetailsAsync(string id)
        {
            var User = await _dbContext.Admins.SingleAsync(User => User.Id == id);

            _dbContext.Entry(User);

            return User;
        }

        public IEnumerable<Admin> GetAllAdminsAsync()
        {
            var User = _dbContext.Admins.Where(User => User.Id != "");

            return User;
        }

        public async Task PutAdminAsync(string id, Admin entity)
        {
            var user = await _dbContext.Admins.SingleAsync(user => user.Id == entity.Id);
            _dbContext.Entry(user).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
