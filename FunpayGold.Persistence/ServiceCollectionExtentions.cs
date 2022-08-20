using FunpayGold.Persistence.DbContexts;
using FunpayGold.Persistence.Entities;
using FunpayGold.Persistence.Repositories.Implementations;
using FunpayGold.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<FunpayGoldDbContext>();

            services.AddDbContext<FunpayGoldDbContext>(options => options.UseNpgsql(connection));

            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IRolesRepository, RolesRepository>();

            services.AddTransient<IBotsRepository, BotsRepository>();

            return services;

        }

    }
}
