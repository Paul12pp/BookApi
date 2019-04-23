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
        public IEnumerable<Libro> GetAll()
        {
            var data = _db.libro
                .OrderByDescending(r=>r.Fecha_p)
                .ToList();
            return data;
        }

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
