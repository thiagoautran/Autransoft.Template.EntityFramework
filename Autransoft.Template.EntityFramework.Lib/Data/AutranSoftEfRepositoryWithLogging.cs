using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autransoft.Template.EntityFramework.Lib.Entities;
using Autransoft.Template.EntityFramework.Lib.Exceptions;
using Autransoft.Template.EntityFramework.Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autransoft.Template.EntityFramework.Lib.Data
{
    public class AutranSoftEfRepositoryWithLogging<Entity, Repository> : IAutranSoftEfRepository<Entity>
        where Entity : AutranSoftEntity
        where Repository : class
    {
        protected readonly IAutranSoftEfLogger<Repository> _logger;
        protected readonly IAutranSoftEfContext _dbContext;

        public AutranSoftEfRepositoryWithLogging(IAutranSoftEfLogger<Repository> logger, IAutranSoftEfContext dbContext)
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
                _logger.LogError(new AutranSoftEfException(ex, entity));
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
                _logger.LogError(new AutranSoftEfException(ex, entity));
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
                _logger.LogError(new AutranSoftEfException(ex, entity));
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
                _logger.LogError(new AutranSoftEfException(ex, entities));
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
                _logger.LogError(new AutranSoftEfException(ex, $"DELETE FROM {tableName};"));
            }
        }
    }
}