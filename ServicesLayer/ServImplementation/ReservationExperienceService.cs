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
    public class ReservationExperienceService  : IReservationExperienceService
    {
        readonly private IGenericRepository<ExperiencesReservation> GenericRepo;
        readonly private IReservationExperienceRepository ExperiencesRepo;

        public ReservationExperienceService(IGenericRepository<ExperiencesReservation> genericRepo, IReservationExperienceRepository _ExperiencesRepo)
        {
            GenericRepo = genericRepo;
            ExperiencesRepo = _ExperiencesRepo;
        }

        public async Task<ExperiencesReservation> DeleteExperiencesReservation(Guid id)
        {
            return await ExperiencesRepo.DeleteExperiencesReservation(id);

        }

        public async Task<ExperiencesReservation> FindExperiencesReservationById(Guid id)
        {
            return await ExperiencesRepo.FindExperiencesReservationById(id);
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetAllClientsExperiencesReservation(string clid)
        {
            return await ExperiencesRepo.GetAllClientsExperiencesReservation(clid);
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetAllHostsExperiencesReservation(string clid)
        {
            return await ExperiencesRepo.GetAllCommercantExperiencesReservation(clid);

        }

        public async Task<IEnumerable<ExperiencesReservation>> GetAllExperiencesReservation()
        {
            return await ExperiencesRepo.GetAllExperiencesReservation();
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationAccepted()
        {
            return await ExperiencesRepo.GetExperiencesReservationAccepted();
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationPaid()
        {
            return await ExperiencesRepo.GetExperiencesReservationPaid();
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationPending()
        {
            return await ExperiencesRepo.GetExperiencesReservationPending();
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationRejected()
        {
            return await ExperiencesRepo.GetExperiencesReservationRejected();
        }

        public async Task<ExperiencesReservation> InsertExperiencesReservation(ExperiencesReservation entity)
        {
            return await ExperiencesRepo.InsertExperiencesReservation(entity);
        }

        public Task UpdateStatus(Guid id, ExperiencesReservation entity)
        {
            return ExperiencesRepo.UpdateStatus(id, entity);
        }
    }
}
