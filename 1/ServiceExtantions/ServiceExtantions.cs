using _1.Interfaces.PrepodInterfaces;
using _1.Interfaces.StepenInterfaces;
namespace _1.ServiceInterfaces
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();
            services.AddScoped<IStepenService, StepenService>();

            return services;
        }
    }
}
