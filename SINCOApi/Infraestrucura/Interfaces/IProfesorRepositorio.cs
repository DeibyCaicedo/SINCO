using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Interfaces
{
    public interface IProfesorRepositorio
    {
        void AgregarProfesor(Profesor profesor);
        void EliminarProfesor(int idProfesor);
        void ActualizarProfesor(Profesor profesor);
        Profesor ConsultarProfesor(int idProfesor);
        List<Profesor> ConsultarTodosProfesores();
    }
}
