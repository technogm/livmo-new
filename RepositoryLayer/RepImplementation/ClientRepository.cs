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
    public class ClientRepository : IClientRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Client> _genericRepoClient;
        public ClientRepository(ApplicationDbContext dbContext, IGenericRepository<Client> GenericRepoClient)
        {
            _dbContext = dbContext;
            _genericRepoClient = GenericRepoClient;
        }
        public async Task<string> Delete(Client entity)
        {
            try
            {

                await _genericRepoClient.DeleteAsync(entity.Id);

            }
            catch (Exception)
            {
                return "fail";

            }
            return "success";
        }

        public async Task<Client> FindByEmail(string mail)
        {
            var user = await _dbContext.Clients.SingleAsync(x => x.Email == mail);
            _dbContext.Entry(user);
            return user;
        }

        public IEnumerable<Client> GetAllClientsAsync()
        {
            var User = _dbContext.Clients.Where(User => User.Id != "");

            return User;
        }

        public async Task<Client> GetClientDetailsAsync(string id)
        {
           
            var client = await _genericRepoClient.GetByIdAsync(id);
            return client;
        
        }

        public async Task PutClientAsync(string id, Client entity)
        {
            var user = await _dbContext.Clients.SingleAsync(user => user.Id == entity.Id);
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
