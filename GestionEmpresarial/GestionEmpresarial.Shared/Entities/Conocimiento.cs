using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Conocimiento
    {

        //primary key
        public int Id { get; set; }

        [Display(Name = "Nombre del Titulo")]
        [Required]
        [MaxLength(100)]
        public string Titulo_Conocimiento { get; set; }


        [Display(Name = "Nombre del Área")]
        [Required]
        [MaxLength(100)]
        public string Area_Conocimiento { get; set; }


        //Relación con la Tabla Tecnico_Conocimiento
        [JsonIgnore]
        public ICollection<Tecnico_Conocimiento> Tecnico_Conocimiento { get; set; }
    }
}
