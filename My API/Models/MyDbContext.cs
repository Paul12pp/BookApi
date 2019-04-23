using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Models
{
    public class MyDbContext:DbContext
    {
        public virtual DbSet<Libro> libro { get; set; }
        public virtual DbSet<Calificacion> calificacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=PruebaApi; User=sa; Password=B1Admin;");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PruebaApi;User=sa; Password=B1Admin;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
