using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class RateViewModel
    {
        [Required]
        public int LibroCodigo { get; set; }
        [Required]
        [Range(-1,1)]
        public int Rate { get; set; }   
    }
}
