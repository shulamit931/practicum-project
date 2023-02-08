using Microsoft.Extensions.DependencyInjection;
using MyProject.Repositories;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public static  class ServiceCollectionExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IPersonService, PersonService>();
            services.AddAutoMapper(typeof(Mapper));
            return services;
        }
    }
}
