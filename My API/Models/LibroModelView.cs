using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class LibroModelView
    {
        public int Codigo { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public DateTime Fecha_p { get; set; }
        [Required]
        public string Autor { get; set; }
    }
}
