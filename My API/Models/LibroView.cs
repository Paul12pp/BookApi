using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class LibroView
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_p { get; set; }
        public string Autor { get; set; }
        public decimal Rate_Average { get; set; }
    }
}
