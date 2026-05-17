using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(x => x.Code);
        builder.Property(x => x.Code).HasColumnType("char(10)");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(300);
        builder.Property(x => x.Description).IsRequired().HasColumnType("nvarchar(max)");
        
        builder.HasOne(x => x.ComponentType)
            .WithMany(x => x.Components)
            .HasForeignKey(x => x.ComponentTypesId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.ComponentManufacturer)
            .WithMany(x => x.Components)
            .HasForeignKey(x => x.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Components");
    }
}