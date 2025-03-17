using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistense.Configuration
{
    public class CustomerSuscriptionConfig : IEntityTypeConfiguration<CustomerSuscription>
    {

        /// <summary>
        /// configura la construccion de la tabla
        /// </summary>
        /// <param name="builder"></param>

        public void Configure(EntityTypeBuilder<CustomerSuscription> builder)
        {
            builder.ToTable("CustomerSuscription");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdCustomer).IsRequired();// Id Customer
            builder.Property(c => c.SuscriptionTypeId).IsRequired();//Id SuscriptionType
            builder.Property(c => c.TypePurchaseId).IsRequired();//Id TypePurchase
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.FinishDate).IsRequired();
        }
    }
}
