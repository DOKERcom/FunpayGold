using FunpayGold.Application.Services.Implementations;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application
{
    public static class ServiceCollectionExtentions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IUsersService, UsersService>();

            services.AddTransient<IBotsService, BotsService>();

            return services;

        }

        

    }
}
