using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Interfaces;
using My_API.Models;

namespace My_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibro _context;
        public LibroController(ILibro context)
        {
            _context = context;
        }
        //public LibroController()
        //{

        //}

        [Route("")]
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            var libros =_context.GetAll();
            return Ok(libros);
        }

        [Route("Rate")]
        [HttpPost]
        public ActionResult<Calificacion> Rate(RateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            
            var result = _context.RateLibro(model);
            switch (result)
            {
                case 201:
                    return Created("/",model);//Ok(result);
                case 404:
                    return NotFound();
                case 500:
                    return BadRequest();
                default:
                    return BadRequest();
            }
        }

        [Route("Post")]
        [HttpPost]
        public ActionResult<Libro> AddLibro(LibroModelView model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _context.AddLibro(model);
            if (result == 201)
            {
                return Created("/", model);
            }
            return BadRequest();
        }

    }
}