﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class LibroModelView
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo titulo es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo descripcion es requerido")]
        public string Descripcion { get; set; }
        public DateTime Fecha_p { get; set; }
        [Required(ErrorMessage = "El campo autor es requerido")]
        public string Autor { get; set; }
    }
}
