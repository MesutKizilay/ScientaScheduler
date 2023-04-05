using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScientaScheduler.Core.Entities.Concrete;

namespace ScientaSchedurler.Application.DataAccess.EntityFramework
{
    public class ScientaContext : DbContext
    {
        //private readonly IConfiguration configuration;

        //public ScientaContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=46.1.103.232,1919;Initial Catalog=GvardalScienta;User ID=GVardal;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<GGorev> GGorevler { get; set; }
        public DbSet<PYProje> PYProjeler { get; set; }
    }
}