using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api CRUD de Alumnos")]
    public class CalificacionesController : ControllerBase
    {
        
        private readonly ICalificacionesRepositorio calificacionesRepositorio;
        public CalificacionesController(ICalificacionesRepositorio calificacionesRepositorio)
        {
            this.calificacionesRepositorio = calificacionesRepositorio;
        }

        /// <summary>
        /// Obtiene la Informacion de todas las calificaciones.
        /// </summary>
        /// <returns></returns>
        // GET: api/<CalificacionesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(calificacionesRepositorio.ConsultarTodosCal());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene la información de una sola calificacion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<calificacionesController>/
        [HttpGet("{id}", Name = "GetCal")]
        public ActionResult Get(int id)
        {
            try
            {
                var cal = calificacionesRepositorio.ConsultarCal(id);
                return Ok(cal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Inserta información de una nueva calificacion
        /// </summary>
        /// <param name="cal"></param>
        /// <returns></returns>
        // POST api/<CalificacionesController>
        [HttpPost]
        public ActionResult Post([FromBody] Calificaciones cal)
        {
            try
            {
                calificacionesRepositorio.AgregarCal(cal);
                return CreatedAtRoute("GetCal", new { id = cal.Id }, cal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza la infromación de una calificacion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cal"></param>
        /// <returns></returns>
        // PUT api/<calificacionesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Calificaciones cal)
        {
            try
            {
                if (cal.Id == id)
                {
                    calificacionesRepositorio.ActualizarCal(cal);
                    return CreatedAtRoute("GetCal", new { id = cal.Id }, cal);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Elimina la información de una calificacion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<CalificacionesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                calificacionesRepositorio.EliminarCal(id);
                return Ok("Se elimino la calificacion correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
