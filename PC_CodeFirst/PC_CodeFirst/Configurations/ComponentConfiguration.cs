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

        builder.HasData(
            new Component
            {
                Code = "INT-I7-12K", Name = "Intel Core i7-12700K", Description = "High performance desktop processor.",
                ComponentManufacturersId = 1, ComponentTypesId = 1
            },
            new Component
            {
                Code = "NVD-RTX407", Name = "NVIDIA GeForce RTX 4070", Description = "Next-gen gaming graphics card.",
                ComponentManufacturersId = 2, ComponentTypesId = 2
            },
            new Component
            {
                Code = "MSI-D5-32G", Name = "MSI Spatium DDR5 32GB", Description = "Ultra-fast 6000MHz RAM kit.",
                ComponentManufacturersId = 3, ComponentTypesId = 3
            }
        );
    }
}