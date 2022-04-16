using ClimaTempoSimples.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClimaTempoSimples.DAL
{
    public class ClimaTempoSimplesContext : DbContext
    {

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<PrevisaoClima> Previsoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}