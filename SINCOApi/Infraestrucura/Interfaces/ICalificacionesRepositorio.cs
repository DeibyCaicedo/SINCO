using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Interfaces
{
    public interface ICalificacionesRepositorio
    {
        void AgregarCal(Calificaciones cal);
        void EliminarCal(int idCal);
        void ActualizarCal(Calificaciones cal);
        Calificaciones ConsultarCal(int idCal);
        List<Calificaciones> ConsultarTodosCal();
    }
}
