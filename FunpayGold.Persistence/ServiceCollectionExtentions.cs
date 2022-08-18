﻿using FunpayGold.Persistence.DbContexts;
using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence
{
    public static class ServiceCollectionExtentions
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<FunpayGoldDbContext>();

            return services;

        }

    }
}
