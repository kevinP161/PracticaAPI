using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Proyecto
    {

        //primary key
        public int Id { get; set; }

        [Display(Name = "Nombre del Proyecto")]
        [Required]
        [MaxLength(70)]
        public string Nombre_proyecto { get; set; }

        [Display(Name = "Fecha de Inicio del Proyecto")]
        [Required]
        public DateTime Fecha_inicio { get; set; }

        [Display(Name = "Fecha de Fin del Proyecto")]
        public DateTime? Fecha_fin { get; set; }



        //Navegation property
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        //Foreign key
        [JsonIgnore]
        public int ClienteId { get; set; }


        //Relacion con la Tabla Asignacion
        [JsonIgnore]
        public ICollection<Asignacion> Asignacion { get; set; }
    }
}
