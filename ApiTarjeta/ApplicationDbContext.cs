using ApiTarjeta.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiTarjeta
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
