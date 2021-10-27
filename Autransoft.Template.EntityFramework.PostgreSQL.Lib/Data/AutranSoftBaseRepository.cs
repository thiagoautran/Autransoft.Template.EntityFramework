using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Entities;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Exceptions;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autransoft.Template.EntityFramework.PostgreSQL.Lib.Data
{
    public class AutranSoftBaseRepository<Entity> : IAutranSoftBaseRepository<Entity>
        where Entity : AutranSoftBaseEntity
    {
        protected readonly IAutranSoftContext _dbContext;

        public AutranSoftBaseRepository(IAutranSoftContext dbContext) => _dbContext = dbContext;

        public async Task<Entity> AddAsync(Entity entity)
        {
            try
            {
                await _dbContext.Set<Entity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                new AutranSoftEntityFrameworkException(ex, entity);
            }

            return entity;
        }

        public async Task UpdateAsync(Entity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                new AutranSoftEntityFrameworkException(ex, entity);
            }
        }

        public async Task DeleteAsync(Entity entity)
        {
            try
            {
                _dbContext.Set<Entity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                new AutranSoftEntityFrameworkException(ex, entity);
            }
        }

        public async Task DeleteAsync(IEnumerable<Entity> entities)
        {
            try
            {
                _dbContext.Set<Entity>().RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                new AutranSoftEntityFrameworkException(ex, entities);
            }
        }

        public async Task DeleteTableAsync(string tableName)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM {tableName};");
            }
            catch(Exception ex)
            {
                new AutranSoftEntityFrameworkException(ex, $"DELETE FROM {tableName};");
            }
        }
    }
}