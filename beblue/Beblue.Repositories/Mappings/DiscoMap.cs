using Beblue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beblue.Repositories.Mappings
{
    public class DiscoMap : IEntityTypeConfiguration<Disco>
    {
        public void Configure(EntityTypeBuilder<Disco> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name);
            builder.Property(c => c.Preco);
            builder.HasOne(x => x.Genero).WithMany().HasForeignKey(x => x.GeneroId);
        }
    }
}
