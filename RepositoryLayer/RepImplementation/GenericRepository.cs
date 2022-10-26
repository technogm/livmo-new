﻿using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.RepImplementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;

        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public GenericRepository()
        {
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return DbSet;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }
        public async Task<TEntity> GetByIdAsync(string id)
        {
            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }



        public async Task InsertAsync(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {


            }

        }

        public async Task PutAsync(int id, TEntity entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }


        }
        public async Task PutAsync(string id, TEntity entity)
        {


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

        public async Task DeleteAsync(string id)
        {
            try
            {
                var entity = await DbSet.FindAsync(id);
                if (entity != null)
                {
                    DbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await DbSet.FindAsync(id);
                if (entity != null)
                {
                    DbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await DbSet.FindAsync(id);
                if (entity != null)
                {
                    DbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {

            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

    }

}