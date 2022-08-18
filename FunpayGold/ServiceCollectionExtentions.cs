using System.Reflection;
using MediatR;

namespace FunpayGold.MVC
{
    public static class ServiceCollectionExtentions
    {

        public static IServiceCollection AddMvcServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;

        }

    }
}
