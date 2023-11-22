using DeliveryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<CardapioModel> Cardapio { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
