using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).IsRequired().HasMaxLength(30);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(300);
        builder.Property(x => x.FoundationDate).IsRequired().HasColumnType("date");
        
        builder.ToTable("ComponentManufacturers");
    }
}