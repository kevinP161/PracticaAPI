using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Entities
{
    public class Cliente
    {

        //primary key
        public int Id { get; set; }


        [Display(Name = "Nombre del Cliente")]
        [Required]
        [MaxLength(50)]
        public string NombreCliente { get; set; }


        //Relacíon con la Tabla Proyecto
        public ICollection<Proyecto> Proyecto { get; set; } = new List<Proyecto>();
    }
}
