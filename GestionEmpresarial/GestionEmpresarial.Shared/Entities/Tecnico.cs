using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Tecnico
    {

        //Primary key
        public int Id { get; set; }

        [Display(Name = "Nombre del Técnico")]
        [Required]
        [MaxLength(50)]
        public string NombreTecnico { get; set; }

        [Display(Name = "Fecha de Alta del Técnico")]
        [Required]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Fecha de Baja del Técnico")]
        public DateTime? FechaBaja { get; set; }


        //Navegation property
        public Empresa Empresa { get; set; }
        public Categoria Categoria { get; set; }

        //Foreign key
        public int EmpresaId { get; set; }
        public int CategoriaId { get; set; }


        //Relacion con la Tabla Asignacion
        public ICollection<Asignacion> Asignacion { get; set; }

        //Relacion con la Tabla Tecnico_Conocimiento
        public ICollection<Tecnico_Conocimiento> Tecnico_Conocimiento { get; set; }
    }
}
