using Microsoft.EntityFrameworkCore;
using project_venda_api.Migrations;
using project_venda_api.Models;
using Titulo = project_venda_api.Models.Titulo;

namespace project_venda_api.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Influenciador> Influenciadores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Cedente> Cedentes { get; set; }
        public DbSet<Sacado> Sacados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Influenciador>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }

    }
}
