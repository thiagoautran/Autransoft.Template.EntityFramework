using Autransoft.Template.EntityFramework.Lib.Exceptions;
using Autransoft.Template.EntityFramework.Lib.Interfaces;
using Microsoft.Extensions.Logging;

namespace Autransoft.Template.EntityFramework.Lib.Loggings
{
    public class AutranSoftEfLogger<Repository> : IAutranSoftEfLogger<Repository>
        where Repository : class
    {
        private readonly ILogger<Repository> _logger;

        public AutranSoftEfLogger(ILoggerFactory loggerFactory) => (_logger) = (loggerFactory.CreateLogger<Repository>());

        public void LogError(AutranSoftEfException autranSoftEfException) => _logger.LogError(autranSoftEfException.LogError<Repository>());
    }
}