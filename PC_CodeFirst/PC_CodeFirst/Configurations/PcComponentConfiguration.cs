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

        builder.HasData(
            new PcComponent { PCId = 1, ComponentCode = "INT-I7-12K", Amount = 1 },
            new PcComponent { PCId = 1, ComponentCode = "NVD-RTX407", Amount = 1 },
            new PcComponent { PCId = 1, ComponentCode = "MSI-D5-32G", Amount = 2 },
            new PcComponent { PCId = 2, ComponentCode = "INT-I7-12K", Amount = 1 },
            new PcComponent { PCId = 2, ComponentCode = "MSI-D5-32G", Amount = 1 },
            new PcComponent { PCId = 3, ComponentCode = "INT-I7-12K", Amount = 1 },
            new PcComponent { PCId = 3, ComponentCode = "NVD-RTX407", Amount = 2 },
            new PcComponent { PCId = 3, ComponentCode = "MSI-D5-32G", Amount = 4 }
        );
    }
}