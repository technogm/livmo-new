using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ServInterface
{
    public interface IReservationTransportService
    {
        public Task<TransportReservation> InsertTransportReservation(TransportReservation entity);
        public Task<TransportReservation> DeleteTransportReservation(Guid id);
        public Task<TransportReservation> FindTransportReservationById(Guid id);
        public Task<IEnumerable<TransportReservation>> GetAllClientsTransportReservation(string clid);
        public Task<IEnumerable<TransportReservation>> GetAllCommercantTransportReservation(string clid);
        public Task<IEnumerable<TransportReservation>> GetTransportReservationPending();
        public Task<IEnumerable<TransportReservation>> GetTransportReservationAccepted();
        public Task<IEnumerable<TransportReservation>> GetTransportReservationRejected();
        public Task<IEnumerable<TransportReservation>> GetTransportReservationPaid();
        public Task<IEnumerable<TransportReservation>> GetAllTransportReservation();
        public Task UpdateStatus(Guid id, TransportReservation entity);
    }
}
