using Microsoft.EntityFrameworkCore;
using GestionEmpresarial.Shared.Entities;   

namespace GestionEmpresarial.API.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options)       {
                
        }

        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conocimiento> Conocimientos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Tecnico_Conocimiento> Tecnico_Conocimientos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
