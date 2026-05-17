using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_CodeFirst.Entities;

namespace PC_CodeFirst.Configurations;

public class PcComponentConfiguration : IEntityTypeConfiguration<PcComponent>
{
    public void Configure(EntityTypeBuilder<PcComponent> builder)
    {
    }
}