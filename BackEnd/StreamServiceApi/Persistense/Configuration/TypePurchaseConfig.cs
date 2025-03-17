using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistense.Configuration
{
    public class TypePurchaseConfig : IEntityTypeConfiguration<TypePurchase>
    {

        public void Configure(EntityTypeBuilder<TypePurchase> builder)
        {
            builder.ToTable("TypePurchases");
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.CustomerSuscriptions).WithOne().HasForeignKey(c => c.TypePurchaseId);// relacion de llave foranea
            builder.Property(c => c.PurchaseDescription).HasMaxLength(25);
            builder.Property(c => c.MonthDuration);
        }
    }
}
