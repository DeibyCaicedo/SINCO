using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Repositorios
{
    public class CalificacionesRepositorio : ICalificacionesRepositorio
    {
        private readonly DataContext context;
        public CalificacionesRepositorio(DataContext context)
        {
            this.context = context;
        }
        public void ActualizarCal(Calificaciones cal)
        {
            context.Entry(cal).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AgregarCal(Calificaciones cal)
        {
            var asig = context.Asignaturas.FirstOrDefault(b => b.Id == cal.AsignaturaId);
            if (cal.Calificacion >= 0 & cal.Calificacion <= 5)
            {
                var calA = context.Calificaciones.FirstOrDefault(a => a.AlumnoId == cal.AlumnoId & a.Anio == cal.Anio & a.AsignaturaId == cal.AsignaturaId);
                var Alum = context.Alumnos.FirstOrDefault(e => e.Id == cal.AlumnoId);
                if (calA == null)
                {
                    context.Calificaciones.Add(cal);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Ya se asigno una calificacion para la asignatura " + asig.Nombre + " en el año " + cal.Anio + " para el alumno "+ Alum.Nombre);
                }
            }
            else
            {
                throw new Exception("La calificacion solo puede estar en un rango de 0 a 5");
            }
        }

        public Calificaciones ConsultarCal(int idCal)
        {
            var cal = context.Calificaciones.FirstOrDefault(a => a.Id == idCal);
            return cal;
        }

        public List<Calificaciones> ConsultarTodosCal() => context.Calificaciones.ToList();

        public void EliminarCal(int idCal)
        {
            var cal = context.Calificaciones.FirstOrDefault(a => a.Id == idCal);
            if (cal != null)
            {
                context.Calificaciones.Remove(cal);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No se pudo eliminar el registro por que no fue encontrado");
            }
        }
    }
}
