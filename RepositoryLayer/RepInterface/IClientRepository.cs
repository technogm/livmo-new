using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IClientRepository
    {
        public Task<Client> GetClientDetailsAsync(string id);
        public Task PutClientAsync(string id, Client entity);
        public IEnumerable<Client> GetAllClientsAsync();
        public Task<Client> FindByEmail(string mail);
       // public Task<string> Delete(Client entity);
    }
}
