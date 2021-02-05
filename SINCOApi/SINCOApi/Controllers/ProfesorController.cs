using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api CRUD de Asignaturas")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorRepositorio ProfesorRepositorio;
        public ProfesorController(IProfesorRepositorio ProfesorRepositorio)
        {
            this.ProfesorRepositorio = ProfesorRepositorio;
        }
        /// <summary>
        /// Obtiene la información de todos los profesores.
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProfesorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(ProfesorRepositorio.ConsultarTodosProfesores());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene la información de un solo profesor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<ProfesorController>/5
        [HttpGet("{id}", Name ="GetProf")]
        public ActionResult Get(int id)
        {
            try
            {
                var prof = ProfesorRepositorio.ConsultarProfesor(id);
                return Ok(prof);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Inserta la información de un nuevo profesor.
        /// </summary>
        /// <param name="prof"></param>
        /// <returns></returns>
        // POST api/<ProfesorController>
        [HttpPost]
        public ActionResult Post([FromBody] Profesor prof)
        {
            try
            {
                ProfesorRepositorio.AgregarProfesor(prof);
                return CreatedAtRoute("GetProf", new { id = prof.Id }, prof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza la información de un profesor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prof"></param>
        /// <returns></returns>
        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profesor prof)
        {
            try
            {
                if (prof.Id == id)
                {
                    ProfesorRepositorio.ActualizarProfesor(prof);
                    return CreatedAtRoute("GetProf", new { id = prof.Id }, prof);
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
        /// Elimina un profesor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ProfesorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                ProfesorRepositorio.EliminarProfesor(id);
                return Ok("Se elimino el profesor correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
