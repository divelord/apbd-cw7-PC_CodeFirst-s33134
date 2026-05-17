using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class PcComponentConfiguration : IEntityTypeConfiguration<PcComponent>
{
    public void Configure(EntityTypeBuilder<PcComponent> builder)
    {
        builder.HasKey(x => new { x.PCId, x.ComponentCode });
        builder.Property(x => x.ComponentCode).HasColumnType("char(10)");
        builder.Property(x => x.Amount).IsRequired();
        
        builder.HasOne(x => x.Pc)
            .WithMany(x => x.PcComponents)
            .HasForeignKey(x => x.PCId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Component)
            .WithMany(x => x.PcComponents)
            .HasForeignKey(x => x.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("PCComponents");
    }
}