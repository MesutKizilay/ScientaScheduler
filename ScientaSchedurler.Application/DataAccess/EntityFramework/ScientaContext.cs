
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScientaScheduler.Core.Entities.Concrete;

namespace ScientaSchedurler.Application.DataAccess.EntityFramework
{
    public class ScientaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = ServerName, 1433; User ID = sa;Database=DbName; Password = **********!; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Gorevler");
            modelBuilder.HasDefaultSchema("InsanKaynaklari");
            //modelBuilder.Entity<IKCalisan>().ToTable("IKCalisanlar", schema: "InsanKaynaklari");
            //modelBuilder.Entity<GGorev>(entity =>
            //{
            //    entity.ToTable("GGorevler", "Gorevler");
            //});
            //modelBuilder.Entity<PYProje>(entity =>
            //{
            //    entity.ToTable("PYProjeler", "ProjeYonetimi");
            //});
        }

        public DbSet<IKCalisan> IKCalisanlar { get; set; }
    }
}
