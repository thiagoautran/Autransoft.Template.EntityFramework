using Autransoft.Template.EntityFramework.Lib.Exceptions;
using Autransoft.Template.EntityFramework.Lib.Interfaces;
using Microsoft.Extensions.Logging;

namespace Autransoft.Template.EntityFramework.Lib.Loggings
{
    public class AutranSoftEntityFrameworkLogger<Repository> : IAutranSoftEntityFrameworkLogger<Repository>
        where Repository : class
    {
        private readonly ILogger<Repository> _logger;

        public AutranSoftEntityFrameworkLogger(ILoggerFactory loggerFactory) => (_logger) = (loggerFactory.CreateLogger<Repository>());

        public void Error(AutranSoftEntityFrameworkException autranSoftEntityFrameworkException) => autranSoftEntityFrameworkException.LogError();
    }
}