using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;



namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        public AlumnoController(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
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

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int idAlumno)
        {
            try
            {
                alumnoRepositorio.EliminarAlumno(idAlumno);
                return Ok("Se elimino el alumbo correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}