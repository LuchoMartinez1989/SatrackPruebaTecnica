using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistense.Contexts;
using Persistense.Repository;


namespace Persistense
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// metodo para cadena de conexion a la capa de persistencia 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddPersistenseInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer
                    (configuration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
        }

    }
}
