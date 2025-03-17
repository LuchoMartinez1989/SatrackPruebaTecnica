using Application.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistense.Configuration
{
    public class SuscriptionTypeConfig : IEntityTypeConfiguration<SuscriptionType>
    {
        public void Configure(EntityTypeBuilder<SuscriptionType> builder)
        {
            builder.ToTable("SuscriptionTypes");
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.CustomerSuscriptions).WithOne().HasForeignKey(c => c.SuscriptionTypeId);// relacion de llave foranea
            builder.Property(c => c.TypeSuscription).HasMaxLength(25);
            builder.Property(c => c.Price);
            builder.Property(c => c.Status).HasMaxLength(15);
        }
    }
}
