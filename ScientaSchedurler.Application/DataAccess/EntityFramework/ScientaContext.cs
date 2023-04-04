using Microsoft.EntityFrameworkCore;
using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientaSchedurler.Application.DataAccess.EntityFramework
{
    public class ScientaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=46.1.103.232,1919;Initial Catalog=GvardalScienta;User ID=GVardal;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<GGorev> GGorevler { get; set; }
        public DbSet<PYProje> PYProjeler { get; set; }
    }
}