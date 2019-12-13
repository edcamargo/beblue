using Beblue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Repositories.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.TotalVenda);
            builder.Property(c => c.ValorCashback);

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId);
        }
    }
}
