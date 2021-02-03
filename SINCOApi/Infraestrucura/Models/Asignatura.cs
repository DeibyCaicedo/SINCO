using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.Models
{
    public class Asignatura
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public Profesor Profesor { get; set; }
    }
}
