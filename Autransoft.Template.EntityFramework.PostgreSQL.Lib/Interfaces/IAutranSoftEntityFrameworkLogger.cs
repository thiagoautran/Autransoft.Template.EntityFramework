using Autransoft.Template.EntityFramework.PostgreSQL.Lib.Exceptions;

namespace Autransoft.Template.EntityFramework.PostgreSQL.Lib.Interfaces
{
    public interface IAutranSoftEntityFrameworkLogger<Repository>
        where Repository : class
    {
        void Error(AutranSoftEntityFrameworkException ex);
    }
}