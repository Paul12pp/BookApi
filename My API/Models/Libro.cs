using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class Libro
    {
        [Key]
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_p { get; set; }
        public string Autor { get; set; }

        public virtual ICollection<Calificacion> Calificacion { get; set; }
    }
}
