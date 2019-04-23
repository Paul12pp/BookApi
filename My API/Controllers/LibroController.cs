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
        /// <summary>
        /// Injeccion de depencia de la 
        /// interfaz
        /// </summary>
        /// <param name="context"></param>
        public LibroController(ILibro context)
        {
            _context = context;
        }

        /// <summary>
        /// La accion principal del controlador
        /// con el listado de los pedidos
        /// con su calificacion
        /// </summary>
        /// <returns>List<LibroView></returns>
        [Route("")]
        [HttpGet]
        public ActionResult<IEnumerable<LibroView>> Get()
        {
            var libros =_context.GetAll();
            return Ok(libros);
        }

        /// <summary>
        /// Metodo post para calificar un libro
        /// retorna un codigo segun el resultado
        /// </summary>
        /// <param name="model"></param>
        /// <returns>StatusCode</returns>
        [Route("Rate")]
        [HttpPost]
        public ActionResult<RateViewModel> Rate(RateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _context.RateLibro(model);
            switch (result)
            {
                case 201:
                    return Created("/",model);
                case 404:
                    return NotFound(model);
                case 500:
                    return BadRequest(model);
                default:
                    return BadRequest(model);
            }
        }

        /// <summary>
        /// Metodo post para crear libro
        /// recibe los parametros especificados
        /// en el archivo. Retorna un codigo de
        /// estatus segun el resultado
        /// </summary>
        /// <param name="model"></param>
        /// <returns>StatusCode</returns>
        [Route("Post")]
        [HttpPost]
        public ActionResult<LibroModelView> AddLibro(LibroModelView model)
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