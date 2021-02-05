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
            context.Calificaciones.Add(cal);
            context.SaveChanges();
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
