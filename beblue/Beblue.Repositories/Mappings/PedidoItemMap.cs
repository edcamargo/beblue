using Beblue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Repositories.Mappings
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.DiscoId);

            builder.HasOne(x => x.Pedido).WithMany().HasForeignKey(x => x.PedidoId);
            builder.HasOne(x => x.Discos).WithMany().HasForeignKey(x => x.DiscoId);
        }
    }
}
