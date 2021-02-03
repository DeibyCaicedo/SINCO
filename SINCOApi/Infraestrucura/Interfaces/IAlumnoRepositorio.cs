using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Interfaces
{

    public interface IAlumnoRepositorio
    {
        void AgregarAlumno(Alumno alumno);
        void EliminarAlumno(int idAlumno);
        void ActualizarAlumno(Alumno alumno);
        Alumno ConsultarAlumno(int idAlumno);
        List<Alumno> ConsultarTodosAlumnos();


    }
}
