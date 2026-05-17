using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        
        builder.ToTable("ComponentTypes");
    }
}