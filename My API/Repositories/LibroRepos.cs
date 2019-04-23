using My_API.Interfaces;
using My_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Repositories
{
    public class LibroRepos : ILibro
    {
        private readonly MyDbContext _db;
        public LibroRepos(MyDbContext dbcontext)
        {
            _db = dbcontext;
        }
        public LibroRepos()
        {

        }

        /// <summary>
        /// Metodo obtener libros
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LibroView> GetAll()
        {
            var data = _db.libro.ToList();
            List<LibroView> libroV = new List<LibroView>();
            foreach (var item in data)
            {
                var rate = _db.calificacion
                    .Where(r => r.LibroCodigo == item.Codigo).ToList();
                decimal calif = (rate.Count > 0)
                    ? Convert.ToDecimal(rate.Sum(r => r.Rate)) / rate.Count
                    : 0;
                calif = Convert.ToDecimal(calif.ToString("0.##"));

                libroV.Add(
                    new LibroView
                    {
                        Codigo=item.Codigo,
                        Titulo = item.Titulo,
                        Descripcion = item.Descripcion,
                        Fecha_p = item.Fecha_p,
                        Autor = item.Autor,
                        Rate_Average = calif
                    });
            }
            
            return libroV
                .OrderByDescending(r => r.Fecha_p)
                .ToList();
        }

        /// <summary>
        /// Metodo agregar libros
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddLibro(LibroModelView model)
        {
            try
            {
                Libro libro = new Libro
                {
                    Titulo = model.Titulo,
                    Descripcion = model.Descripcion,
                    Fecha_p = DateTime.Now,
                    Autor = model.Autor
                };
                _db.libro.Add(libro);
                _db.SaveChanges();
                return 201;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        /// <summary>
        /// Metodo calificar libro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int RateLibro(RateViewModel model)
        { 
            try
            {
                var libro = _db.libro
                .SingleOrDefault(r => r.Codigo == model.LibroCodigo);
                if (libro == null)
                {
                    return 404;
                }
                Calificacion cal = new Calificacion
                {
                    LibroCodigo = model.LibroCodigo,
                    Rate = model.Rate
                };
                if (cal.Rate == 0) { return 500;}
                _db.calificacion.Add(cal);
                _db.SaveChanges();
                return 201;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
