using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace Application
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Agregar Todas las dependencias para el proyecto
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());//se agregan dependencias a nivel de mapper
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // agregar el  media tr 
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatonBeahavior<,>));

        }

    }
}
