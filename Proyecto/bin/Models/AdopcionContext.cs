using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models
{
    public class AdopcionContext : DbContext
    {
        public DbSet<Mascota> Mascotas { get; set; }

        public AdopcionContext(DbContextOptions<AdopcionContext> options) : base(options) { }

    }
}