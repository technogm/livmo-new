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
    public class LikesRepository : ILikesRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<ServicesLikes> _genericRepoExp;

        public LikesRepository(ApplicationDbContext dbContext, IGenericRepository<ServicesLikes> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }

        public async Task<string> DeleteServicesLikes(Guid ClientId)
        {
            try
            {
                _dbContext.ServicesLikes.RemoveRange(_dbContext.ServicesLikes.Where(x => x.ServiceLikeId == ClientId));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "fail";

            }
            return "success";
        }

        public async Task<ServicesLikes> FindLikeById(Guid id)
        {
            var exp = await _dbContext.ServicesLikes

                          .FirstOrDefaultAsync(n => n.ServiceLikeId == id);

            return exp;
        }

        public async Task<IEnumerable<ServicesLikes>> GetExperienceServicesLikes(Guid clientId)
        {
            var exp = await _dbContext.ServicesLikes
                                                        .Where(p => p.ExperienceId == clientId).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ServicesLikes>> GetFoodServicesLikes(Guid HostId)
        {
            var exp = await _dbContext.ServicesLikes
                                                        .Where(p => p.FoodServId == HostId).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ServicesLikes>> GetLodgingServicesLikes(Guid HostId)
        {
            var exp = await _dbContext.ServicesLikes
                                                                   .Where(p => p.LodgingId == HostId).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<ServicesLikes>> GetTransportServicesLikes(Guid HostId)
        {
            var exp = await _dbContext.ServicesLikes
                                                                   .Where(p => p.TransportId == HostId).ToListAsync();
            return exp;
        }

        public async Task<ServicesLikes> InsertServicesLikes(ServicesLikes entity)
        {
            await _dbContext.ServicesLikes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
