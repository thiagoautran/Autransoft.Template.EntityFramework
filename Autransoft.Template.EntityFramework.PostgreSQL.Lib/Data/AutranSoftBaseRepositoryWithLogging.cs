using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Entities;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Exceptions;
using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autransoft.Template.EntityFramework.PostgreSQL.Lib.Data
{
    public class AutranSoftBaseRepositoryWithLogging<Entity, Repository> : IAutranSoftBaseRepository<Entity>
        where Entity : AutranSoftBaseEntity
        where Repository : class
    {
        protected readonly IAutranSoftEntityFrameworkLogger<Repository> _logger;
        protected readonly IAutranSoftContext _dbContext;

        public AutranSoftBaseRepositoryWithLogging(IAutranSoftEntityFrameworkLogger<Repository> logger, IAutranSoftContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        } 

        public async Task<Entity> AddAsync(Entity entity)
        {
            try
            {
                await _dbContext.Set<Entity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.Error(new AutranSoftEntityFrameworkException(ex, entity));
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
                _logger.Error(new AutranSoftEntityFrameworkException(ex, entity));
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
                _logger.Error(new AutranSoftEntityFrameworkException(ex, entity));
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
                _logger.Error(new AutranSoftEntityFrameworkException(ex, entities));
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
                _logger.Error(new AutranSoftEntityFrameworkException(ex, $"DELETE FROM {tableName};"));
            }
        }
    }
}