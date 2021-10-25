using System.Threading.Tasks;
using Autransoft.Template.EntityFramework.Lib.Entities;

namespace Autransoft.Template.EntityFramework.Lib.Interfaces
{
    public interface IAutransoftBaseRepository<Entity>
        where Entity : BaseEntity
    {
        Task<Entity> AddAsync(Entity entity);

        Task UpdateAsync(Entity entity);

        Task DeleteTableAsync(string tableName);
    }
}