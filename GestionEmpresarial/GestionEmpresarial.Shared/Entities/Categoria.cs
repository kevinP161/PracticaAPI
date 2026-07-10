using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Categoria
    {

        //primary key
        public int Id { get; set; }


        [Display(Name = "Nombre de la Categoria")]
        [Required]
        [MaxLength(20)]
        public string NombreCategoria { get; set; }


        //Relacion con la Tabla Tecnico

        public ICollection<Tecnico> Tecnico { get; set; }
    }
}
