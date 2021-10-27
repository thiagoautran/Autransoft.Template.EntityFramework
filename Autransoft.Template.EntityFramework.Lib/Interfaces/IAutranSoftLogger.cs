using Autransoft.Template.EntityFramework.Lib.Exceptions;

namespace Autransoft.Template.EntityFramework.Lib.Interfaces
{
    public interface IAutranSoftLogger<Repository>
        where Repository : class
    {
        void Error(AutranSoftEfException autranSoftEfException);
    }
}