using System;
using System.Net.Http;
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
        /// <param name="options">Configure the options for the HttpMessenger</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddHttpMessenger(this IServiceCollection services, Action<HttpMessenger> options = null)
        {
            var httpMessenger = new HttpMessenger();
            options?.Invoke(httpMessenger);
            
            services.AddScoped<IHttpMessenger, HttpMessenger>(opt =>
            {
                var messenger = new HttpMessenger
                {
                    Client = httpMessenger.Client ?? opt.GetService<HttpClient>(),
                    JsonOptions = httpMessenger.JsonOptions
                };

                return messenger;
            });

            return services;
        }
    }
}