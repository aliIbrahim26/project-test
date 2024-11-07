using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLand_Persistence.Repositories;
using PostLands_Application.Contract;

namespace PostLand_Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceContainer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IBasicService<>),typeof(GenricRepo<>));
            services.AddScoped(typeof(ISecondServiceCategory), typeof(ServiceCategoryRepo));
            services.AddScoped(typeof(ISecondServicePost), typeof(ServicePostRepo));

            services.AddDbContext<PostLandDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            return services;
        }
    }
}
