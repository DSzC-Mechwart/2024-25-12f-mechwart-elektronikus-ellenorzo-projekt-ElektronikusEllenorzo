using DH_EE_IKT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DH_EE_IKT_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Szak> Szakok { get; set; }
        public DbSet<Osztaly> Osztalyok { get; set; }
        public DbSet<Tanulo> Tanulok { get; set; }
        public DbSet<Jegy> Jegyek { get; set; }
        public DbSet<Tanar> Tanarok { get; set; }
        public DbSet<Tantargy> Tantargyak { get; set; }
        public DbSet<Tanora> Tanorak { get; set; }
        public DbSet<Orarend> Orarendek { get; set; }
    }
}
