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
    public class TransportServices : ITransportService
    {
        readonly private IGenericRepository<TransportService> GenericRepo;
        readonly private ITransportServiceRepository _TransportServiceRepo;

        public TransportServices(IGenericRepository<TransportService> genericRepo, ITransportServiceRepository TransportServiceRepo)
        {
            GenericRepo = genericRepo;
            _TransportServiceRepo = TransportServiceRepo;
        }

        public async Task<TransportService> DeleteTransportService(TransportService entity)
        {
            return await _TransportServiceRepo.DeleteTransportService(entity);
        }

        public async Task<TransportService> DeleteTransportService(Guid id)
        {
            return await _TransportServiceRepo.DeleteTransportService(id);
        }

        public async Task<TransportService> FindTransportServiceById(Guid id)
        {
            return await _TransportServiceRepo.FindTransportById(id);
        }

        public IEnumerable<TransportService> GetAllTransportServices()
        {
            return GenericRepo.GetAll();

        }

        public async Task<IEnumerable<TransportService>> GetAllCommercantTransportServices(string HostId)
        {
            return await _TransportServiceRepo.GetCommercantTransportServices(HostId);

        }


        public async Task<TransportService> InsertTransportService(TransportService entity)
        {
            return await _TransportServiceRepo.InsertTransportService(entity);
        }

        public Task UpdateTransportServiceAsync(Guid id, TransportService TransportService)
        {
            return _TransportServiceRepo.PutTransportServiceAsync(id, TransportService);

        }

        public  List<string> GetAllTransServiceImagesLink(Guid expId)
        {
            return  _TransportServiceRepo.GetAllTransServiceImagesLink(expId);
        }

        public Task<IEnumerable<TransportService>> GetCommercantValidTransport(string id)
        {
            return _TransportServiceRepo.GetCommercantValidTransport(id);
        }

        public Task<IEnumerable<TransportService>> GetCommercantInValidTransport(string id)
        {
            return _TransportServiceRepo.GetCommercantInValidTransport(id);
        }

        public Task<IEnumerable<TransportService>> GetCommercanEnAttenteTransport(string id)
        {
            return _TransportServiceRepo.GetCommercanEnAttenteTransport(id);
        }

        public Task<IEnumerable<TransportService>> GetAllValidTransport()
        {
            return _TransportServiceRepo.GetAllValidTransport();
        }

        public List<Guid> getAllTransportIDS(Guid expId)
        {
            return _TransportServiceRepo.getAllTransportIDS(expId);

        }
    }
}
