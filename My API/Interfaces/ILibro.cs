using My_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Interfaces
{
    public interface ILibro
    {
        IEnumerable<Libro> GetAll();
        int RateLibro(RateViewModel model);
        int AddLibro(LibroModelView model);
    }
}
