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
    public class ActivityRepository : IActivityRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Activity> _genericRepoExp;

        public ActivityRepository(ApplicationDbContext dbContext, IGenericRepository<Activity> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<Activity> DeleteActivity(Activity entity)
        {
            var exp = await _dbContext.Activity.FindAsync(entity.activiteId);
            if (exp != null)
            {
                _dbContext.Activity.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<Activity> DeleteActivity(Guid id)
        {
            var exp = await _dbContext.Activity.FindAsync(id);
            if (exp != null)
            {
                _dbContext.Activity.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<Activity> FindActivityById(Guid id)
        {
            var exp = await _dbContext.Activity
                           .SingleAsync(n => n.activiteId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<Activity>> GetSpecificActivity(Guid expId)
        {
            var exp = await _dbContext.Activity
                                         //  .Include(u => u.Experience)
                                           .Where(p => p.ExperienceId == expId).ToListAsync();
            return exp;
        }

        public async Task<Activity> InsertActivity(Activity entity)
        {
            await _dbContext.Activity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public List<string> GetAllActivityLinks(Guid expId)
        {
            var links = new List<string>();
            var Exp = _dbContext.Activity.SingleOrDefault(exp => exp.activiteId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Activityphoto)
                .Load();

            foreach (var link in Exp.Activityphoto)
            {
                System.Console.WriteLine(link.Url);
                links.Add(link.Url);

            }
            return links;
        }
        public List<Guid> getAllActivityIDS(Guid expId)
        {
            var links = new List<Guid>();
            var Exp = _dbContext.Activity.SingleOrDefault(exp => exp.activiteId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Activityphoto)
                .Load();

            foreach (var link in Exp.Activityphoto)
            {
                System.Console.WriteLine(link.Id);
                links.Add(link.Id);

            }
            return links;
        }
    }
}
