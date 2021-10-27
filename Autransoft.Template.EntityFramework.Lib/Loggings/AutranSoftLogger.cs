using Autransoft.Template.EntityFramework.Lib.Exceptions;
using Autransoft.Template.EntityFramework.Lib.Interfaces;
using Microsoft.Extensions.Logging;

namespace Autransoft.Template.EntityFramework.Lib.Loggings
{
    public class AutranSoftLogger<Repository> : IAutranSoftLogger<Repository>
        where Repository : class
    {
        private readonly ILogger<Repository> _logger;

        public AutranSoftLogger(ILoggerFactory loggerFactory) => (_logger) = (loggerFactory.CreateLogger<Repository>());

        public void Error(AutranSoftEfException autranSoftEfException) => _logger.LogError(autranSoftEfException.LogError());
    }
}