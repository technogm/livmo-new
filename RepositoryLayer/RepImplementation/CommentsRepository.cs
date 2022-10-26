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
    public class CommentsRepository : ICommentsRepository
    {
        public readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Comments> _genericRepoExp;

        public CommentsRepository(ApplicationDbContext dbContext, IGenericRepository<Comments> GenericRepoExp)
        {
            _dbContext = dbContext;
            _genericRepoExp = GenericRepoExp;
        }

        public async Task<string> DeleteComments(Guid ClientId)
        {
            try
            {
                _dbContext.Comments.RemoveRange(_dbContext.Comments.Where(x => x.CommentId == ClientId));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "fail";

            }
            return "success";
        }

        public async Task<Comments> FindComById(Guid id)
        {
            var exp = await _dbContext.Comments
                         
                          .FirstOrDefaultAsync(n => n.CommentId == id);

            return exp;
        }

        public async Task<IEnumerable<Comments>> GetExperienceComments(Guid clientId)
        {
            var exp = await _dbContext.Comments
                                                        .Where(p => p.ExperienceId == clientId).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<Comments>> GetFoodComments(Guid HostId)
        {
            var exp = await _dbContext.Comments
                                                        .Where(p => p.FoodServId == HostId).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<Comments>> GetLodgingComments(Guid HostId)
        {
            var exp = await _dbContext.Comments
                                                                   .Where(p => p.LodgingId == HostId).ToListAsync();
            return exp;
        }

        public async Task<IEnumerable<Comments>> GetTransportComments(Guid HostId)
        {
            var exp = await _dbContext.Comments
                                                                   .Where(p => p.TransportId == HostId).ToListAsync();
            return exp;
        }

        public async Task<Comments> InsertComments(Comments entity)
        {
            await _dbContext.Comments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
