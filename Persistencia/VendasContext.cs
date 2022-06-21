using Microsoft.EntityFrameworkCore;
using TesteVendas.Models;

namespace TesteVendas.Persistencia
{
    public class VendasContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }



        public VendasContext(DbContextOptions op) : base(op) { }


    }
}
