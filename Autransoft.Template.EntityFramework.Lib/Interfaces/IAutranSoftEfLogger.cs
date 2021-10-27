using Autransoft.Template.EntityFramework.Lib.Exceptions;

namespace Autransoft.Template.EntityFramework.Lib.Interfaces
{
    public interface IAutranSoftEfLogger<Repository>
        where Repository : class
    {
        void LogError(AutranSoftEfException autranSoftEfException);
    }
}