using System.Reflection;
using MediatR;

namespace FunpayGold.API
{
    public static class ServiceCollectionExtentions
    {

        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;

        }

    }
}
