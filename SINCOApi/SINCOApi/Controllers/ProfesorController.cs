using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorRepositorio ProfesorRepositorio;
        public ProfesorController(IProfesorRepositorio ProfesorRepositorio)
        {
            this.ProfesorRepositorio = ProfesorRepositorio;
        }
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
