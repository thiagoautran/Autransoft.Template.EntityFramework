using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Autransoft.Template.EntityFramework.Lib.Helpers
{
    public static class AutranSoft
    {
        public static EntityFramework.Lib.DTOs.Autransoft LoadDatabase(IServiceCollection serviceColletion, IConfiguration configuration)
        {
            serviceColletion.Configure<EntityFramework.Lib.DTOs.Autransoft>(configuration.GetSection("Autransoft"));

            var appSettings = new EntityFramework.Lib.DTOs.Autransoft();
            new ConfigureFromConfigurationOptions<EntityFramework.Lib.DTOs.Autransoft>(configuration.GetSection("Autransoft")).Configure(appSettings);

            return appSettings;
        }
    }
}