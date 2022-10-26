using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepInterface
{
    public interface IReservationExperienceRepository
    {
        public Task<ExperiencesReservation> InsertExperiencesReservation(ExperiencesReservation entity);
        public Task<ExperiencesReservation> DeleteExperiencesReservation(Guid id);
        public Task<ExperiencesReservation> FindExperiencesReservationById(Guid id);
        public Task<IEnumerable<ExperiencesReservation>> GetAllClientsExperiencesReservation(string clid);
        public Task<IEnumerable<ExperiencesReservation>> GetAllCommercantExperiencesReservation(string clid);
        public Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationPending();
        public Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationAccepted();
        public Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationRejected();
        public Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationPaid();
        public Task<IEnumerable<ExperiencesReservation>> GetAllExperiencesReservation();
        public Task UpdateStatus(Guid id, ExperiencesReservation entity);
    }
}
