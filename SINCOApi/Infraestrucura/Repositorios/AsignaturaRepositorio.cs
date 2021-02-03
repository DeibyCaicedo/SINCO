using Infraestructura.Interfaces;
using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Repositorios
{
    public class AsignaturaRepositorio : IAsignaturaRepositorio
    {
        private readonly DataContext context;
        public AsignaturaRepositorio(DataContext context)
        {
            this.context = context;
        }
        public void ActualizarAsignatura(Asignatura asignatura)
        {
            context.Entry(asignatura).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AgregarAsignatura(Asignatura asignatura)
        {
            context.Asignaturas.Add(asignatura);
            context.SaveChanges();
        }

        public Asignatura ConsultarAsignatura(int idAsignatura)
        {
            var asig = context.Asignaturas.FirstOrDefault(a => a.Id == idAsignatura);
            return asig;
        }

        public List<Asignatura> ConsultarTodosAsignaturas() => context.Asignaturas.ToList();

        public void EliminarAsignatura(int idAsignatura)
        {
            var asig = context.Asignaturas.FirstOrDefault(a => a.Id == idAsignatura);
            if (asig != null)
            {
                context.Asignaturas.Remove(asig);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No se pudo eliminar la asignatura por que no fue encontrado");
            }
        }
    }
}
