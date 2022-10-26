using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IReservationLodgingRepository
    {
        public Task<LodgingReservation> InsertLodgingReservation(LodgingReservation entity);
        public Task<LodgingReservation> DeleteLodgingReservation(Guid id);
        public Task<LodgingReservation> FindLodgingReservationById(Guid id);
        public Task<IEnumerable<LodgingReservation>> GetAllClientsLodgingReservation(string clid);
        public Task<IEnumerable<LodgingReservation>> GetAllCommercantLodgingReservation(string clid);
        public Task<IEnumerable<LodgingReservation>>  GetLodgingReservationPending();
        public Task<IEnumerable<LodgingReservation>> GetLodgingReservationAccepted();
        public Task<IEnumerable<LodgingReservation>> GetLodgingReservationRejected();
        public Task<IEnumerable<LodgingReservation>> GetLodgingReservationPaid();
        public Task<IEnumerable<LodgingReservation>> GetAllLodgingReservation();
        public Task UpdateStatus(Guid id, LodgingReservation entity);
    }
}
