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
    public class ReservationLodgingService : IReservationLodgingService
    {
        readonly private IGenericRepository<LodgingService> GenericRepo;
        readonly private IReservationLodgingRepository LodgingRepo;

        public ReservationLodgingService(IGenericRepository<LodgingService> genericRepo, IReservationLodgingRepository _LodgingRepo)
        {
            GenericRepo = genericRepo;
            LodgingRepo = _LodgingRepo;
        }

        public async Task<LodgingReservation> DeleteLodgingReservation(Guid id)
        {
            return await LodgingRepo.DeleteLodgingReservation(id);

        }

        public async Task<LodgingReservation> FindLodgingReservationById(Guid id)
        {
            return await LodgingRepo.FindLodgingReservationById(id);
        }

        public async Task<IEnumerable<LodgingReservation>> GetAllClientsLodgingReservation(string clid)
        {
            return await LodgingRepo.GetAllClientsLodgingReservation(clid);
        }

        public async Task<IEnumerable<LodgingReservation>> GetAllCommercantLodgingReservation(string clid)
        {
            return await LodgingRepo.GetAllCommercantLodgingReservation(clid);

        }

        public async Task<IEnumerable<LodgingReservation>> GetAllLodgingReservation()
        {
            return await LodgingRepo.GetAllLodgingReservation();
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationAccepted()
        {
            return await LodgingRepo.GetLodgingReservationAccepted();
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationPaid()
        {
            return await LodgingRepo.GetLodgingReservationPaid();
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationPending()
        {
            return await LodgingRepo.GetLodgingReservationPending();
        }

        public async Task<IEnumerable<LodgingReservation>> GetLodgingReservationRejected()
        {
            return await LodgingRepo.GetLodgingReservationRejected();
        }

        public async Task<LodgingReservation> InsertLodgingReservation(LodgingReservation entity)
        {
            return await LodgingRepo.InsertLodgingReservation(entity);
        }

        public Task UpdateStatus(Guid id, LodgingReservation entity)
        {
            return LodgingRepo.UpdateStatus(id, entity);
        }
    }
}
