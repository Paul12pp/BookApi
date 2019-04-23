using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class Calificacion
    {
        [Key]
        public int CodigoC { get; set; }
        public int LibroCodigo { get; set; }
        public int Rate { get; set; }

        public virtual Libro Libro { get; set; }
    }
}
