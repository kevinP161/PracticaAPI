using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Asignacion
    {
        public int Id { get; set; }


        [Display(Name = "Fecha de Asignacíon del Proyecto")]
        [Required]
        public DateTime Fecha_asignacion { get; set; }

        [Display(Name = "Fecha de Finalización del Proyecto")]
        public DateTime? Fecha_finalizacion { get; set; }


        //Foreign key
        public int TecnicoId { get; set; }
        public int ProyectoId { get; set; }

        //Navegation property
        [JsonIgnore]
        public Tecnico Tecnico { get; set; }

        [JsonIgnore]
        public Proyecto Proyecto { get; set; }

    }
}
