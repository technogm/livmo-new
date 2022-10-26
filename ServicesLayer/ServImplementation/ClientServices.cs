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
    public class ClientServices : IClientservice
    {
        readonly private IGenericRepository<Client> GenericRepo;
        readonly private IClientRepository ClientRepo;
        public ClientServices(IGenericRepository<Client> _GenericRepo, IClientRepository _CompanyRepo)
        {
            GenericRepo = _GenericRepo;
            ClientRepo = _CompanyRepo;
        }
        public Task AddClientAsync(Client Client)
        {
            return GenericRepo.InsertAsync(Client);
        }

        public Task DeleteClientAsync(Client Client)
        {
            return GenericRepo.DeleteAsync(Client.Id);
        }

        public IList<Client> GetAllClients()
        {
            return ClientRepo.GetAllClientsAsync().ToList();
        }

        public Task<Client> GetClientByEmail(string email)
        {
            return ClientRepo.GetClientDetailsAsync(email);
        }

        public async Task<Client> GetClientById(string id)
        {
            return await ClientRepo.GetClientDetailsAsync(id);
        }

        public Task UpdateClientAsync(string id, Client Client)
        {
            return ClientRepo.PutClientAsync(id, Client);
        }
    }
}
