using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public static class DbSeed
    {
        public static void SeedData(MyDbContext context)
        {
            var check = context.Database.EnsureCreated();
            if (check)
            {
                InsertData(context);
            }
        }

        public static void InsertData (MyDbContext context)
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
    }
}
