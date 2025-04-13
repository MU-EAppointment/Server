using EAppointment.Domain.Entities;
using EAppointment.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace EAppointment.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<EAppointmentDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("SQL"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddIdentity<User, Role>(action =>
            {
                action.Password.RequiredLength = 1;
                action.Password.RequireUppercase = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
                action.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<EAppointmentDbContext>();

            services.Scan(action =>
            {
                action.FromAssemblies(typeof(ServiceRegistration).Assembly)
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });


            //services.AddScoped<IQueryRepository<Doctor>, DoctorQueryRepository>();
            //services.AddScoped<ICommandRepository<Doctor>, DoctorCommandRepository>();
            //services.AddScoped<IQueryRepository<Patient>, PatientQueryRepository>();
            //services.AddScoped<ICommandRepository<Patient>, PatientCommandRepository>();
            //services.AddScoped<IQueryRepository<Appointment>, AppointmentQueryRepository>();
            //services.AddScoped<ICommandRepository<Appointment>, AppointmentCommandRepository>();

            return services;
        }
    }
}
