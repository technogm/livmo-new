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
    public class DatesExpRepository : IDatesExpRepository

    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<ExperienceDates> _genericRepoExp;
        public DatesExpRepository(ApplicationDbContext dbContext, IGenericRepository<ExperienceDates> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }

        public async Task<ExperienceDates> DeleteExperienceDates(Guid id)
        {
            var exp = await _dbContext.ExperienceDates.FindAsync(id);
            if (exp != null)
            {
                _dbContext.ExperienceDates.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

     
        public async Task<IEnumerable<ExperienceDates>> GetExperienceDates(Guid expId)
        {
            var exp = await _dbContext.ExperienceDates
                                                      .Include(u => u.Experience)
                                                      .Where(p => p.ExperienceId == expId).ToListAsync();
            return exp;
        }

        public async Task<ExperienceDates> InsertExperienceDates(ExperienceDates entity)
        {
            await _dbContext.ExperienceDates.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
