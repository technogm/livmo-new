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
   public class FoodExpRepository : IFoodExpRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<FoodExperience> _genericRepoExp;

        public FoodExpRepository(ApplicationDbContext dbContext, IGenericRepository<FoodExperience> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }
        public async Task<FoodExperience> DeleteFoodExperience(FoodExperience entity)
        {
            var exp = await _dbContext.Foodxperience.FindAsync(entity.FoodId);
            if (exp != null)
            {
                _dbContext.Foodxperience.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<FoodExperience> DeleteFoodExperience(Guid id)
        {
            var exp = await _dbContext.Foodxperience.FindAsync(id);
            if (exp != null)
            {
                _dbContext.Foodxperience.Remove(exp);
                await _dbContext.SaveChangesAsync();
            }
            return exp;
        }

        public async Task<FoodExperience> FindFoodById(Guid id)
        {
            var exp = await _dbContext.Foodxperience
                           .SingleAsync(n => n.FoodId == id);
            _dbContext.Entry(exp);
            return exp;
        }

        public async Task<IEnumerable<FoodExperience>> GetSpecificFoodExperiences(Guid expId)
        {
            var exp = await _dbContext.Foodxperience
                                          // .Include(u => u.Experience)
                                           .Where(p => p.ExperienceId == expId).ToListAsync();
            return exp;
        }

        public async Task<FoodExperience> InsertFoodExperience(FoodExperience entity)
        {
            await _dbContext.Foodxperience.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public List<string> GetAllFoodExperienceImagesLink(Guid expId)
        {
            var links = new List<string>();
            var Exp = _dbContext.Foodxperience.SingleOrDefault(exp => exp.FoodId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Foodphoto)
                .Load();

            foreach (var link in Exp.Foodphoto)
            {
                System.Console.WriteLine(link.Url);
                links.Add(link.Url);

            }
            return links;
        }

        public List<Guid> getAllFoodExpIDS(Guid expId)
        {
            var links = new List<Guid>();
            var Exp = _dbContext.Foodxperience.SingleOrDefault(exp => exp.FoodId == expId);
            _dbContext.Entry(Exp).
                Collection(Exp => Exp.Foodphoto)
                .Load();

            foreach (var link in Exp.Foodphoto)
            {
                System.Console.WriteLine(link.Id);
                links.Add(link.Id);

            }
            return links;
        }
    }
}
