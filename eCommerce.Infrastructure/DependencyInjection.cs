
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastucture services to the independency injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services){
            //TO DO:Add services to the IoC container
            //Infrastucture services often include data access , caching and another low-level components
            services.AddTransient<IUsersRepository,UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;

        }
    }
}