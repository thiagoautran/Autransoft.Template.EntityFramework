using System.Threading.Tasks;
using Autransoft.Template.EntityFramework.Lib.Entities;

namespace Autransoft.Template.EntityFramework.Lib.Interfaces
{
    public interface IAutranSoftBaseRepository<Entity>
        where Entity : AutranSoftBaseEntity
    {
        Task<Entity> AddAsync(Entity entity);

        Task UpdateAsync(Entity entity);

        Task DeleteTableAsync(string tableName);
    }
}