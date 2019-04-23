using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class RateViewModel
    {
        [Required(ErrorMessage ="El campo LibroCodigo es requerido")]
        public int LibroCodigo { get; set; }
        [Required(ErrorMessage ="El campo Rate es requerido")]
        [Range(-1,1,ErrorMessage ="La calificación debe ser -1 o 1.")]
        public int Rate { get; set; }   
    }
}
