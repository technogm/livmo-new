using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface ITransportService
    {
        public Task<TransportService> InsertTransportService(TransportService entity);
        public Task<TransportService> DeleteTransportService(TransportService entity);
        public Task<TransportService> DeleteTransportService(Guid id);
        public Task<TransportService> FindTransportServiceById(Guid id);
        public IEnumerable<TransportService> GetAllTransportServices();
        public Task<IEnumerable<TransportService>> GetAllCommercantTransportServices(string HostId);
        public Task<IEnumerable<TransportService>> GetCommercantValidTransport(string id);
        public Task<IEnumerable<TransportService>> GetCommercantInValidTransport(string id);
        public Task<IEnumerable<TransportService>> GetCommercanEnAttenteTransport(string id);
        public Task UpdateTransportServiceAsync(Guid id, TransportService TransportService);
        public List<string> GetAllTransServiceImagesLink(Guid expId);
        public Task<IEnumerable<TransportService>> GetAllValidTransport();
        public List<Guid> getAllTransportIDS(Guid expId);



    }
}
