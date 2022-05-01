using HttpClientMessenger.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientMessenger
{
    public static class RegisterHttpMessengerExtension
    {
        /// <summary>
        /// Registers the HttpMessenger to the services container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddHttpMessenger(this IServiceCollection services)
        {
            services.AddScoped<IHttpMessenger, HttpMessenger>();
            return services;
        }
    }
}