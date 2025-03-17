using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistense.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// configura la construccion de la tabla
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.CustomerSuscriptions).WithOne().HasForeignKey(c=>c.IdCustomer);// relacion de llave foranea
            builder.Property(c => c.IdenticacionCode).HasMaxLength(15).IsRequired(false);
            builder.Property(c => c.Password).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Lastnames).HasMaxLength(40).IsRequired();
            builder.Property(c => c.Mail).HasMaxLength(50).IsRequired();

        }
    }
}
