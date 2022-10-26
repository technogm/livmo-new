using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IClientservice
    {
        public Task AddClientAsync(Client Client);
        public IList<Client> GetAllClients();
        public Task UpdateClientAsync(string id,Client Client);
        public Task<Client> GetClientById(string id);
        public Task DeleteClientAsync(Client Client);
        public Task<Client> GetClientByEmail(string email);
        
    }
}
