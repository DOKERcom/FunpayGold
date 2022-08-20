using System.Reflection;
using FunpayGold.MVC.Initializators.Implementations;
using FunpayGold.MVC.Initializators.Intefaces;
using MediatR;

namespace FunpayGold.MVC
{
    public static class ServiceCollectionExtentions
    {

        public static IServiceCollection AddMvcServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IAdminInitializer, AdminInitializer>();

            services.AddTransient<IRoleInitializer, RoleInitializer>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;

        }

    }
}
