using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PostLands_Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationContainer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
