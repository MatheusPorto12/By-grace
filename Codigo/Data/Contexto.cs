using ByGrace.Classes;
using Microsoft.EntityFrameworkCore;

namespace ByGrace.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Produtos> Produtos { get; set; }
	    public DbSet<Cliente> Cliente { get; set; }
	    public DbSet<Pedido> Pedido { get; set; }
	    public DbSet<PedidoProduto> PedidoProduto { get; set; }

    }
}
