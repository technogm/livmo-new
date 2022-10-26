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
    public class ReservationTransportService : IReservationTransportService
    {
        readonly private IGenericRepository<TransportService> GenericRepo;
        readonly private IReservationTransportRepository TransportRepo;

        public ReservationTransportService(IGenericRepository<TransportService> genericRepo, IReservationTransportRepository _TransportRepo)
        {
            GenericRepo = genericRepo;
            TransportRepo = _TransportRepo;
        }

        public async Task<TransportReservation> DeleteTransportReservation(Guid id)
        {
            return await TransportRepo.DeleteTransportReservation(id);

        }

        public async Task<TransportReservation> FindTransportReservationById(Guid id)
        {
            return await TransportRepo.FindTransportReservationById(id);
        }

        public async Task<IEnumerable<TransportReservation>> GetAllClientsTransportReservation(string clid)
        {
            return await TransportRepo.GetAllClientsTransportReservation(clid);
        }

        public async Task<IEnumerable<TransportReservation>> GetAllCommercantTransportReservation(string clid)
        {
            return await TransportRepo.GetAllCommercantTransportReservation(clid);

        }

        public async Task<IEnumerable<TransportReservation>> GetAllTransportReservation()
        {
            return await TransportRepo.GetAllTransportReservation();
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationAccepted()
        {
            return await TransportRepo.GetTransportReservationAccepted();
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationPaid()
        {
            return await TransportRepo.GetTransportReservationPaid();
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationPending()
        {
            return await TransportRepo.GetTransportReservationPending();
        }

        public async Task<IEnumerable<TransportReservation>> GetTransportReservationRejected()
        {
            return await TransportRepo.GetTransportReservationRejected();
        }

        public async Task<TransportReservation> InsertTransportReservation(TransportReservation entity)
        {
            return await TransportRepo.InsertTransportReservation(entity);
        }

        public  Task UpdateStatus(Guid id, TransportReservation entity)
        {
            return  TransportRepo.UpdateStatus(id,entity);
        }
    }
}
