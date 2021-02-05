using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Infraestructura.Models
{
    public class Calificaciones
    {
        [Key]
        public int Id { get; set; }
        public int Anio { get; set; }
        public double Calificacion { get; set; }
        public int AlumnoId { get; set; }
        public int AsignaturaId { get; set; }

        public Alumno Alumnos { get; set; }
        public Asignatura Asignaturas { get; set; } 
    }

}
