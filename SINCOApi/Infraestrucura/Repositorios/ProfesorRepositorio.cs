using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Repositorios
{
    public class ProfesorRepositorio : IProfesorRepositorio
    {
        private readonly DataContext context;
        public ProfesorRepositorio(DataContext context)
        {
            this.context = context;
        }
        public void ActualizarProfesor(Profesor profesor)
        {
            context.Entry(profesor).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AgregarProfesor(Profesor profesor)
        {
            context.profesores.Add(profesor);
            context.SaveChanges();
        }

        public Profesor ConsultarProfesor(int idProfesor)
        {
            var prof = context.profesores.FirstOrDefault(a => a.Id == idProfesor);
            return prof;
        }

        public List<Profesor> ConsultarTodosProfesores() => context.profesores.ToList();

        public void EliminarProfesor(int idProfesor)
        {
            var prof = context.profesores.FirstOrDefault(a => a.Id == idProfesor);
            if (prof != null)
            {
                context.profesores.Remove(prof);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No se pudo eliminar el profesor por que no fue encontrado");
            }
        }
    }
}
