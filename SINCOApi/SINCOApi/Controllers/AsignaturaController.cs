using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System;
using System.Linq;

namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Api CRUD de Asignaturas")]
    public class AsignaturaController : ControllerBase
    {
        private readonly IAsignaturaRepositorio asignaturaRepositorio;
        public AsignaturaController(IAsignaturaRepositorio asignaturaRepositorio)
        {
            this.asignaturaRepositorio = asignaturaRepositorio;
        }
        /// <summary>
        /// Obtiene la Informacion de todos los asignaturas.
        /// </summary>
        /// <returns></returns>
        // GET: api/<AsignaturaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(asignaturaRepositorio.ConsultarTodosAsignaturas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene la información de una sola asignatura.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<AsignaturaController>/5
        [HttpGet("{id}", Name = "GetAsig")]
        public ActionResult Get(int id)
        {
            try
            {
                var asig = asignaturaRepositorio.ConsultarAsignatura(id);
                return Ok(asig);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Inserta información de una nueva asignatura.
        /// </summary>
        /// <param name="asig"></param>
        /// <returns></returns>
        // POST api/<AsignaturaController>
        [HttpPost]
        public ActionResult Post([FromBody] Asignatura asig)
        {
            try
            {
                asignaturaRepositorio.AgregarAsignatura(asig);
                return CreatedAtRoute("GetAsig", new { id = asig.Id }, asig);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Inserta informacion de una nueva asignatura.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asig"></param>
        /// <returns></returns>
        // PUT api/<AsignaturaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Asignatura asig)
        {
            try
            {
                if (asig.Id == id)
                {
                    asignaturaRepositorio.ActualizarAsignatura(asig);
                    return CreatedAtRoute("GetAsig", new { id = asig.Id }, asig);
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
        /// Elimina una asignatura.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<AsignaturaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                asignaturaRepositorio.EliminarAsignatura(id);
                return Ok("Se elimino la asignatura correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}