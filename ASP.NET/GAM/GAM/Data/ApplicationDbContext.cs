using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GAM.Models;

namespace GAM.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<GAM.Models.Autore> Autore { get; set; } = default!;
        public DbSet<GAM.Models.Opera> Opera { get; set; } = default!;
        public DbSet<GAM.Models.Materiale> Materiale { get; set; } = default!;
    }
}
