using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Api.Domain.IService;
using Api.Domain.Service;
using Microsoft.AspNetCore.Builder;

namespace Api.Domain.Config
{
    public static class Configuration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            Repository.Config.Configuration.Configure(services, configuration);
            var assembliesService = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "Api.Domain")
                 .FirstOrDefault().GetTypes();
            var serviceList = assembliesService
                .Where(x => x.Name.EndsWith("Service") && !x.Name.StartsWith("I"));

            foreach (var service in serviceList)
            {
                var nameService = service.Name;
                var iService = assembliesService.Where(a => a.Name == "I" + nameService).FirstOrDefault();
                if (iService != null)
                {
                    services.AddScoped(iService, service);
                }
            }
        }

        public static void ConfigureApp(IApplicationBuilder app)
        {
            Repository.Config.Configuration.ConfigureApp(app);
        }
    }
}
