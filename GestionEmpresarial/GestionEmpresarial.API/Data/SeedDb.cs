using GestionEmpresarial.Shared.Entities;
using GestionEmpresarial.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Crea la base de datos si no existe
            await _context.Database.EnsureCreatedAsync();

            await SeedCategoriasAsync();
            await SeedEmpresasAsync();
            await SeedClientesAsync();
            await SeedConocimientosAsync();
            await SeedTecnicosAsync();
            await SeedProyectosAsync();
            await SeedAsignacionesAsync();
            await SeedTecnicoConocimientosAsync();
        }

        private async Task SeedCategoriasAsync()
        {
            if (_context.Categorias.Any())
                return;

            _context.Categorias.AddRange(
                new Categoria { NombreCategoria = "Backend" },
                new Categoria { NombreCategoria = "Frontend" },
                new Categoria { NombreCategoria = "Base de Datos" },
                new Categoria { NombreCategoria = "DevOps" }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedEmpresasAsync()
        {
            if (_context.Empresas.Any())
                return;

            _context.Empresas.AddRange(
                new Empresa { NombreEmpresa = "Microsoft" },
                new Empresa { NombreEmpresa = "Google" },
                new Empresa { NombreEmpresa = "Oracle" }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedClientesAsync()
        {
            if (_context.Clientes.Any())
                return;

            _context.Clientes.AddRange(
                new Cliente { NombreCliente = "Bancolombia" },
                new Cliente { NombreCliente = "Sura" },
                new Cliente { NombreCliente = "Grupo Éxito" }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedConocimientosAsync()
        {
            if (_context.Conocimientos.Any())
                return;

            _context.Conocimientos.AddRange(
                new Conocimiento
                {
                    Titulo_Conocimiento = "C#",
                    Area_Conocimiento = "Backend"
                },
                new Conocimiento
                {
                    Titulo_Conocimiento = "ASP.NET Core",
                    Area_Conocimiento = "Backend"
                },
                new Conocimiento
                {
                    Titulo_Conocimiento = "SQL Server",
                    Area_Conocimiento = "Base de Datos"
                },
                new Conocimiento
                {
                    Titulo_Conocimiento = "Blazor",
                    Area_Conocimiento = "Frontend"
                },
                new Conocimiento
                {
                    Titulo_Conocimiento = "Docker",
                    Area_Conocimiento = "DevOps"
                }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedTecnicosAsync()
        {
            if (_context.Tecnicos.Any())
                return;

            _context.Tecnicos.AddRange(
                new Tecnico
                {
                    NombreTecnico = "Kevin Porras",
                    FechaAlta = DateTime.Today.AddYears(-2),
                    EmpresaId = 1,
                    CategoriaId = 1
                },
                new Tecnico
                {
                    NombreTecnico = "Laura Gómez",
                    FechaAlta = DateTime.Today.AddYears(-1),
                    EmpresaId = 2,
                    CategoriaId = 2
                },
                new Tecnico
                {
                    NombreTecnico = "Carlos Ramírez",
                    FechaAlta = DateTime.Today.AddMonths(-10),
                    EmpresaId = 3,
                    CategoriaId = 3
                }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedProyectosAsync()
        {
            if (_context.Proyectos.Any())
                return;

            _context.Proyectos.AddRange(
                new Proyecto
                {
                    Nombre_proyecto = "Sistema de Inventario",
                    Fecha_inicio = DateTime.Today.AddMonths(-4),
                    Fecha_fin = DateTime.Today.AddMonths(2),
                    ClienteId = 1
                },
                new Proyecto
                {
                    Nombre_proyecto = "Portal de Clientes",
                    Fecha_inicio = DateTime.Today.AddMonths(-2),
                    Fecha_fin = DateTime.Today.AddMonths(5),
                    ClienteId = 2
                },
                new Proyecto
                {
                    Nombre_proyecto = "Gestión de Ventas",
                    Fecha_inicio = DateTime.Today,
                    Fecha_fin = DateTime.Today.AddMonths(8),
                    ClienteId = 3
                }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedAsignacionesAsync()
        {
            if (_context.Asignaciones.Any())
                return;

            _context.Asignaciones.AddRange(
                new Asignacion
                {
                    Fecha_asignacion = DateTime.Today.AddMonths(-3),
                    Fecha_finalizacion = DateTime.Today.AddMonths(2),
                    TecnicoId = 1,
                    ProyectoId = 1
                },
                new Asignacion
                {
                    Fecha_asignacion = DateTime.Today.AddMonths(-1),
                    Fecha_finalizacion = DateTime.Today.AddMonths(5),
                    TecnicoId = 2,
                    ProyectoId = 2
                },
                new Asignacion
                {
                    Fecha_asignacion = DateTime.Today,
                    Fecha_finalizacion = DateTime.Today.AddMonths(8),
                    TecnicoId = 3,
                    ProyectoId = 3
                }
            );

            await _context.SaveChangesAsync();
        }

        private async Task SeedTecnicoConocimientosAsync()
        {
            if (_context.Tecnico_Conocimientos.Any())
                return;

            _context.Tecnico_Conocimientos.AddRange(
                new Tecnico_Conocimiento
                {
                    TecnicoId = 1,
                    ConocimientoId = 1,
                    Grado = GradoConocimiento.Experto
                },
                new Tecnico_Conocimiento
                {
                    TecnicoId = 1,
                    ConocimientoId = 2,
                    Grado = GradoConocimiento.Avanzado
                },
                new Tecnico_Conocimiento
                {
                    TecnicoId = 2,
                    ConocimientoId = 4,
                    Grado = GradoConocimiento.Avanzado
                },
                new Tecnico_Conocimiento
                {
                    TecnicoId = 3,
                    ConocimientoId = 3,
                    Grado = GradoConocimiento.Experto
                },
                new Tecnico_Conocimiento
                {
                    TecnicoId = 3,
                    ConocimientoId = 5,
                    Grado = GradoConocimiento.Intermedio
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}