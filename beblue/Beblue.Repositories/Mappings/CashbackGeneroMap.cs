using Beblue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Repositories.Mappings
{
    public class CashbackGeneroMap : IEntityTypeConfiguration<CashbackGenero>
    {
        public void Configure(EntityTypeBuilder<CashbackGenero> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.DiaSemana);
            builder.Property(c => c.PercentualCashbackDia);
            builder.HasOne(x => x.Genero).WithMany().HasForeignKey(x => x.GeneroId);
        }
    }
}
