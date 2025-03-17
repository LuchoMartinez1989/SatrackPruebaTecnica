using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using Domain.Common;
using System.Reflection;


namespace Persistense.Contexts
{
    /// <summary>
    /// esta clase maneja las propiedades de conexion a Bd
    /// </summary>
    public class AppDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime; 

        public AppDbContext(DbContextOptions<AppDbContext> options,IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }

        public DbSet<Customer> Customers{ get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>()) {

                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.Created = _dateTime.NowUTC;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModified = _dateTime.NowUTC;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// aplica las configuraciones
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }


}
