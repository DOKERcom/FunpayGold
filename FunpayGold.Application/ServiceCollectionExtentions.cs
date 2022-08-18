using FunpayGold.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application
{
    public static class ServiceCollectionExtentions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddPersistenceServices(configuration.GetSection("PersistenceServices"));

            return services;

        }

        

    }
}
