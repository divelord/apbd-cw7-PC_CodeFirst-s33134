using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class PcConfiguration : IEntityTypeConfiguration<Pc>
{
    public void Configure(EntityTypeBuilder<Pc> builder)
    {
    }
}