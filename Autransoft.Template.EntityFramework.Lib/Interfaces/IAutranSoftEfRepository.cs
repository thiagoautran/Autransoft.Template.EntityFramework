using System.Threading.Tasks;
using Autransoft.Template.EntityFramework.Lib.Entities;

namespace Autransoft.Template.EntityFramework.Lib.Interfaces
{
    public interface IAutranSoftEfRepository<Entity> : IAutranSoftEfRepository
        where Entity : AutranSoftEntity
    {
        Task<Entity> AddAsync(Entity entity);

        Task UpdateAsync(Entity entity);
    }

    public interface IAutranSoftEfRepository { }
}