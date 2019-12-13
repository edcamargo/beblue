using Beblue.Domain.Entities;
using Beblue.Repositories.Mappings;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace Beblue.Repositories.Context
{
    public class BeblueContext : DbContext
    {

        #region "Objetos"

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Disco> Disco { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<CashbackGenero> CashbackGenero { get; set; }

        #endregion

        #region "Construtores"

        public BeblueContext() { }

        public BeblueContext(DbContextOptions<BeblueContext> options) : base(options) {
            Database.Migrate();
            Database.EnsureCreated();
        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("dbBeblue");

            if (!Directory.Exists(@"c:\temp-ed"))
            {
                Directory.CreateDirectory(@"c:\temp-ed");
            }

            optionsBuilder.UseSqlite("Data Source=C:/temp-ed/dbBeblue.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("db");

            builder.ApplyConfiguration(new PedidoMap());
            builder.ApplyConfiguration(new ClienteMap());
        }
    }
}
