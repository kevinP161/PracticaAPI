using Microsoft.EntityFrameworkCore;
using GestionEmpresarial.Shared.Entities;   

namespace GestionEmpresarial.API.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options)       {
                
        }

        public DbSet<Empresa> Empresas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
