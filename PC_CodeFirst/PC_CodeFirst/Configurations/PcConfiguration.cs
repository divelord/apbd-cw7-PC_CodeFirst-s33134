using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class PcConfiguration : IEntityTypeConfiguration<Pc>
{
    public void Configure(EntityTypeBuilder<Pc> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Weight).HasColumnType("float(5)").IsRequired();
        builder.Property(x => x.Warranty).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();
        builder.Property(x => x.Stock).IsRequired();
        
        builder.ToTable("PCs");
        
        builder.HasData(
            new Pc { Id = 1, Name = "Gaming Master Pro", Weight = 12.5, Warranty = 24, CreatedAt = new DateTime(2026, 1, 15), Stock = 5 },
            new Pc { Id = 2, Name = "Office Workstation", Weight = 8.2, Warranty = 12, CreatedAt = new DateTime(2026, 2, 10), Stock = 10 },
            new Pc { Id = 3, Name = "Creator Studio X", Weight = 14.1, Warranty = 36, CreatedAt = new DateTime(2026, 3, 20), Stock = 3 }
        );
    }
}