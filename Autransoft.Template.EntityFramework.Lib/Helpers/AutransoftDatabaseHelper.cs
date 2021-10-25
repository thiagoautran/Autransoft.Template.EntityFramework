using Autransoft.Template.EntityFramework.Lib.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Autransoft.Template.EntityFramework.Lib.Helpers
{
    public static class AutransoftDatabaseHelper
    {
        public static AutransoftDatabase LoadAppSettings(IServiceCollection serviceColletion, IConfiguration configuration)
        {
            serviceColletion.Configure<AutransoftDatabase>(configuration.GetSection("AutransoftDatabase"));

            var appSettings = new AutransoftDatabase();
            new ConfigureFromConfigurationOptions<AutransoftDatabase>(configuration.GetSection("AutransoftDatabase")).Configure(appSettings);

            return appSettings;
        }
    }
}