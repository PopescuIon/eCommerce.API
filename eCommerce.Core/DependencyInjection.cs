

using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
         /// <summary>
        /// Extension method to add core services to the independency injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services){
            //TO DO:Add services to the IoC container
            //Core services often include data access , caching and another low-level components
            services.AddTransient<IUsersService,UsersService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}