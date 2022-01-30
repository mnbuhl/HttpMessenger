using HttpService.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HttpService
{
    public static class RegisterHttpServiceExtension
    {
        /// <summary>
        /// Registers the HttpService to the services container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddHttpService(this IServiceCollection services)
        {
            services.AddScoped<IHttpService, Service.HttpService>();
            return services;
        }
    }
}