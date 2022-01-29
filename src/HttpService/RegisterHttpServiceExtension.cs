using HttpService.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HttpService
{
    public static class RegisterHttpServiceExtension
    {
        public static IServiceCollection AddHttpService(this IServiceCollection services)
        {
            services.AddScoped<IHttpService, Service.HttpService>();
            return services;
        }
    }
}