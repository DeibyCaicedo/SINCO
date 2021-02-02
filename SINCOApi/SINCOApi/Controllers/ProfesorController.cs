using SINCOApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SINCOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly DataContext context;
        public ProfesorController(DataContext context)
        {
            this.context = context;
        }
        // GET: api/<ProfesorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.profesores.ToList());
            }catch(Exception ex)
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
                var Prof = context.profesores.FirstOrDefault(p => p.Id == id);
                return Ok(Prof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProfesorController>
        [HttpPost]
        public ActionResult Post([FromBody] Profesor Prof)
        {
            try
            {
                context.profesores.Add(Prof);
                context.SaveChanges();
                return CreatedAtRoute("GetProf", new { id = Prof.Id },Prof);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profesor Prof)
        {
            try
            {
                if (Prof.Id == id)
                {
                    context.Entry(Prof).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProf", new { id = Prof.Id }, Prof);
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
                var Prof = context.profesores.FirstOrDefault(p => p.Id == id);
                if (Prof != null)
                {
                    context.profesores.Remove(Prof);
                    context.SaveChanges();
                    return Ok(id);
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
    }
}
