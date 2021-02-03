using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Repositorios
{

    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        private readonly DataContext context;
        public AlumnoRepositorio(DataContext context)
        {
            this.context = context;
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            context.Entry(alumno).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AgregarAlumno(Alumno alumno)
        {
            context.Alumnos.Add(alumno);
            context.SaveChanges();
        }

        public Alumno ConsultarAlumno(int idAlumno)
        {
            var alum = context.Alumnos.FirstOrDefault(a => a.Id == idAlumno);
            return alum;
        }

        public List<Alumno> ConsultarTodosAlumnos()=> context.Alumnos.ToList();

        public void EliminarAlumno(int idAlumno)
        {

            var Alum = context.Alumnos.FirstOrDefault(a => a.Id == idAlumno);
            if (Alum != null)
            {
                context.Alumnos.Remove(Alum);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No se pudo eliminar el alumno por que no fue encontrado");
            }
        }


    }
}

