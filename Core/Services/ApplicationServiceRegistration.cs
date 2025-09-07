using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;
using Services.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServicesManager, ServiceManager>();
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            return services;
        }

    }
}
