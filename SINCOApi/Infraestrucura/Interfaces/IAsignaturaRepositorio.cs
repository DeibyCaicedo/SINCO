using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Interfaces
{
    public interface IAsignaturaRepositorio
    {
        void AgregarAsignatura(Asignatura Asignatura);
        void EliminarAsignatura(int idAsignatura);
        void ActualizarAsignatura(Asignatura Asignatura);
        Asignatura ConsultarAsignatura(int idAsignatura);
        List<Asignatura> ConsultarTodosAsignaturas();

    }
}
