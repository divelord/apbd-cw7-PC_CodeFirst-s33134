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

        builder.HasData(
            new ComponentManufacturer
            {
                Id = 1, Abbreviation = "INTC", FullName = "Intel Corporation",
                FoundationDate = new DateTime(1968, 7, 18)
            },
            new ComponentManufacturer
            {
                Id = 2, Abbreviation = "NVDA", FullName = "NVIDIA Corporation",
                FoundationDate = new DateTime(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3, Abbreviation = "MSI", FullName = "Micro-Star International",
                FoundationDate = new DateTime(1986, 8, 4)
            }
        );
    }
}