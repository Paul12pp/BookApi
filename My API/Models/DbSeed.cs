using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public static class DbSeed
    {
        /// <summary>
        /// Metodo inicializador de la Db
        /// verifica si exite, si no, la cra.
        /// </summary>
        /// <param name="context"></param>
        public static void SeedData(MyDbContext context)
        {
            var check = context.Database.EnsureCreated();
            if (check)
            {
                InsertBooks(context);
                InsertRates(context);
            }
        }

        /// <summary>
        /// Metodo inserta libros
        /// </summary>
        /// <param name="context"></param>
        public static void InsertBooks (MyDbContext context)
        {
            context.libro.AddRange(new List<Libro>
            {
                new Libro
                {
                    Titulo="100 años de soledad",
                    Descripcion="Excelente",
                    Fecha_p= Convert.ToDateTime("11/11/2017"),
                    Autor="Gabriel García Márquez",
                },
                new Libro
                {
                    Titulo="Crimen y Castigo",
                    Descripcion="Muy bueno",
                    Fecha_p= Convert.ToDateTime("11/11/2018"),
                    Autor="Fedor Dostoievski",
                },
                new Libro
                {
                    Titulo="La casa de los espíritus",
                    Descripcion="Muy bueno",
                    Fecha_p= Convert.ToDateTime("11/11/2019"),
                    Autor="Isabel Allende",
                   
                },
                new Libro
                {
                    Titulo="Fahrenheit 451",
                    Descripcion="Muy bueno",
                    Fecha_p= Convert.ToDateTime("11/11/2015"),
                    Autor="Ray Bradbury",

                },new Libro
                {
                    Titulo="La metamorfosis",
                    Descripcion="Muy bueno",
                    Fecha_p= Convert.ToDateTime("11/11/2016"),
                    Autor="Franz Kafka",

                }
            });
            context.SaveChanges();
        }

        /// <summary>
        /// Metodo inserta calificaciones
        /// </summary>
        /// <param name="context"></param>
        private static void InsertRates(MyDbContext context)
        {
            context.calificacion.AddRange(new List<Calificacion>
            {
                new Calificacion
                {
                    LibroCodigo=1,
                    Rate=1,
                },new Calificacion
                {
                    LibroCodigo=1,
                    Rate=-1,
                },
                new Calificacion
                {
                    LibroCodigo=1,
                    Rate=1,
                },
                new Calificacion
                {
                    LibroCodigo=1,
                    Rate=1,
                },
                new Calificacion
                {
                    LibroCodigo=2,
                    Rate=-1,
                },
                new Calificacion
                {
                    LibroCodigo=2,
                    Rate=1,
                },
                new Calificacion
                {
                    LibroCodigo=2,
                    Rate=1,
                },
                new Calificacion
                {
                    LibroCodigo=3,
                    Rate=1,
                },
                new Calificacion
                {
                    LibroCodigo=4,
                    Rate=1,
                }
            });
            context.SaveChanges();
        }

    }
}
