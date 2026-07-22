using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Tecnico_Conocimiento
    {

        public int  Id { get; set; }

        [Display(Name = "Grado de Conocimiento")]
        [Required]
        public string Grado { get; set; }


        //Foreign key
        [JsonIgnore]
        public int TecnicoId { get; set; }
        [JsonIgnore]
        public int ConocimientoId { get; set; }


        //Navegation property
        [JsonIgnore]
        public Tecnico Tecnico { get; set; }

        [JsonIgnore]
        public Conocimiento Conocimiento { get; set; }
    }
}
