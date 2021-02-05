using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;



namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api CRUD de Alumnos")] 
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        public AlumnoController(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }

        /// <summary>
        /// Obtiene la Informacion de todos los alumnos.
        /// </summary>
        /// <returns></returns>
        // GET: api/<AlumnoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(alumnoRepositorio.ConsultarTodosAlumnos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene la información de un solo alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<AlumnoController>/5
        [HttpGet("{id}", Name = "GetAlum")]
        public ActionResult Get(int id)
        {
            try
            {
                var Alum = alumnoRepositorio.ConsultarAlumno(id);
                return Ok(Alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Inserta información de un nuevo alumno 
        /// </summary>
        /// <param name="alum"></param>
        /// <returns></returns>
        // POST api/<AlumnoController>
        [HttpPost]
        public ActionResult Post([FromBody] Alumno alum)
        {
            try
            {
                alumnoRepositorio.AgregarAlumno(alum);
                return CreatedAtRoute("GetAlum", new { id = alum.Id }, alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza la infromación de un alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alum"></param>
        /// <returns></returns>
        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alum)
        {
            try
            {
                if (alum.Id == id)
                {
                    alumnoRepositorio.ActualizarAlumno(alum);
                    return CreatedAtRoute("GetAlum", new { id = alum.Id }, alum);
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
        /// Elimina la información de un alumno siempre y cuando no tenga materias asignadas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                alumnoRepositorio.EliminarAlumno(id);
                return Ok("Se elimino el alumno correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}