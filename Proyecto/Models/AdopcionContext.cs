using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models
{
    public class AdopcionContext : IdentityDbContext
    {
        public DbSet<Mascota> Mascotas { get; set; }

        public AdopcionContext(DbContextOptions<AdopcionContext> options) : base(options) { }

    }
}