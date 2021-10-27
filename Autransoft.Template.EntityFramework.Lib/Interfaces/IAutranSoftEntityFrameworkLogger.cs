using Autransoft.Template.EntityFramework.Lib.Exceptions;

namespace Autransoft.Template.EntityFramework.Lib.Interfaces
{
    public interface IAutranSoftEntityFrameworkLogger<Repository>
        where Repository : class
    {
        void Error(AutranSoftEntityFrameworkException ex);
    }
}