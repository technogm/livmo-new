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
    public class LodgingExpRepository : ILodgingExpRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<LodgingExperience> _genericRepoExp;

        public LodgingExpRepository(ApplicationDbContext dbContext, IGenericRepository<LodgingExperience> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<LodgingExperience> DeleteLodgingExperience(LodgingExperience entity)
        {
            var exp = await _dbContext.LodgingExperience.FindAsync(entity.LodgingId);
            if (exp != null)
            {
                _dbContext.LodgingExperience.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<LodgingExperience> DeleteLodgingExperience(Guid id)
        {
            var exp = await _dbContext.LodgingExperience.FindAsync(id);
            if (exp != null)
            {
                _dbContext.LodgingExperience.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<LodgingExperience> FindLodgingById(Guid id)
        {
            var exp = await _dbContext.LodgingExperience
                        .SingleAsync(n => n.LodgingId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<LodgingExperience>> GetLodgingExperiences(Guid expId)
        {
            var exp = await _dbContext.LodgingExperience
                                         //  .Include(u => u.Experience)
                                           .Where(p => p.ExperienceId == expId).ToListAsync();
            return exp;
        }

        public async Task<LodgingExperience> InsertLodgingExperience(LodgingExperience entity)
        {
            await _dbContext.LodgingExperience.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public List<string> GetAllLdogingExperienceImagesLink(Guid expId)
        {
            var links = new List<string>();
            var Exp = _dbContext.LodgingExperience.SingleOrDefault(exp => exp.LodgingId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Lodgingphoto)
                .Load();

            foreach (var link in Exp.Lodgingphoto)
            {
                System.Console.WriteLine(link.Url);
                links.Add(link.Url);

            }
            return links;
        }

        public List<Guid> getAllLodgingExpIDS(Guid expId)
        {
            var links = new List<Guid>();
            var Exp = _dbContext.LodgingExperience.SingleOrDefault(exp => exp.LodgingId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Lodgingphoto)
                .Load();

            foreach (var link in Exp.Lodgingphoto)
            {
                System.Console.WriteLine(link.Id);
                links.Add(link.Id);

            }
            return links;
        }
    }
}

    