using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private readonly IAsignaturaRepositorio asignaturaRepositorio;
        public AsignaturaController(IAsignaturaRepositorio asignaturaRepositorio)
        {
            this.asignaturaRepositorio = asignaturaRepositorio;
        }
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