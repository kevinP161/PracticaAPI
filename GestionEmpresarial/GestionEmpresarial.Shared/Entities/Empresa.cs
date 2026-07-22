using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Empresa
    {
        //primary key
        public int Id { get; set; }


        [Display(Name ="Nombre de la Empresa")]
        [Required]
        [MaxLength(50)]
        public string NombreEmpresa { get; set; }


        //Relacion con la Tabla Tecnico
        [JsonIgnore]
        public ICollection<Tecnico> Tecnico { get; set; }
    }
}
