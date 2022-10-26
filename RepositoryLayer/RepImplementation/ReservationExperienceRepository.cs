using DataLayer.Data;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepImplementation
{
    public class ReservationExperienceRepository : IReservationExperienceRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<ExperiencesReservation> _genericRepoExp;

        public ReservationExperienceRepository(ApplicationDbContext dbContext, IGenericRepository<ExperiencesReservation> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<ExperiencesReservation> DeleteExperiencesReservation(Guid id)
        {
            var exp = await _dbContext.ExperienceReservations.FindAsync(id);
            if (exp != null)
            {
                _dbContext.ExperienceReservations.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<ExperiencesReservation> FindExperiencesReservationById(Guid id)
        {
            var exp = await _dbContext.ExperienceReservations
                                      .SingleAsync(n => n.ExperienceReservationId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetAllClientsExperiencesReservation(string clid)
        {
            var exp = await _dbContext.ExperienceReservations
                            .Where(p => p.ClientId == clid).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetAllCommercantExperiencesReservation(string clid)
        {
            var query = await (from b in _dbContext.ExperienceReservations
                             join com in _dbContext.Experience
                             on b.ExperienceId equals com.ExperienceId
                             where com.HostId == clid
                             select new
                             {
                                 b.EndDate,
                                 b.StartDate,
                                 b.Seats,
                                 b.Price,
                                 b.Status,
                                 b.IntervalTime,
                                 b.ClientId,
                                 b.ExperienceId,
                                 b.ExperienceReservationId,
                                 com.HostId,
                             }).ToListAsync();

            List<ExperiencesReservation> userRolesModels = new List<ExperiencesReservation>();
            if (query.Count > 0)
            {
                for (int i = 0; i < query.Count; i++)
                {
                    var model = new ExperiencesReservation
                    {
                        EndDate = query[i].EndDate,
                        ClientId = query[i].ClientId,
                        ExperienceReservationId = query[i].ExperienceReservationId,
                        Seats = query[i].Seats,
                        Price = query[i].Price,
                        StartDate = query[i].StartDate,
                        Status = query[i].Status,
                        IntervalTime = query[i].IntervalTime,
                        ExperienceId = query[i].ExperienceId
                    };
                    userRolesModels.Add(model);
                }
            }
            return userRolesModels;

        }

        public async Task<IEnumerable<ExperiencesReservation>> GetAllExperiencesReservation()
        {
            var User = await _dbContext.ExperienceReservations.Where(User => User.ExperienceReservationId == User.ExperienceReservationId).ToListAsync();

            return User;
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationAccepted()
        {
            var exp = await _dbContext.ExperienceReservations
                                                 .Where(p => p.Status.StartsWith("Accepted")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationPaid()
        {
            var exp = await _dbContext.ExperienceReservations.Where(p => p.Status.StartsWith("Paid")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationPending()
        {
            var exp = await _dbContext.ExperienceReservations.Where(p => p.Status.StartsWith("Pending")).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ExperiencesReservation>> GetExperiencesReservationRejected()
        {
            var exp = await _dbContext.ExperienceReservations.Where(p => p.Status.StartsWith("Rejected")).ToListAsync();
            return exp;
        }

        public async Task<ExperiencesReservation> InsertExperiencesReservation(ExperiencesReservation entity)
        {
            await _dbContext.ExperienceReservations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateStatus(Guid id, ExperiencesReservation entity)
        {
            var user = await _dbContext.ExperienceReservations.SingleAsync(user => user.ExperienceReservationId == entity.ExperienceReservationId);
            _dbContext.Entry(user).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
