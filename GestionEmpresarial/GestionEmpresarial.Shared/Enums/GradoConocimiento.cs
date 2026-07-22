using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresarial.Shared.Enums
{
    public enum GradoConocimiento
    {
        [Display(Name = "Básico")]
        Basico,
        [Display(Name = "Intermedio")]
        Intermedio,
        [Display(Name = "Avanzado")]
        Avanzado,
        [Display(Name = "Experto")]
        Experto
    }
}
