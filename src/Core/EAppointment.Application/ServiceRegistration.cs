using EAppointment.Application.Features.Auths.Rules;
using EAppointment.Application.Features.Doctors.Rules;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EAppointment.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
            services.AddScoped<AuthRules>();
            services.AddScoped<DoctorRules>();
            return services;
        }
    }
}
