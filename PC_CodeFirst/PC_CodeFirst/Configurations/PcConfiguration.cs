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
    }
}