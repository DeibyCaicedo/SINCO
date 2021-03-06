﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infraestructura.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Identificación { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellido { get; set; }
        public int Edad { get; set; }
        [MaxLength(50)]
        public string Dirección { get; set; }
        [MaxLength(15)]
        public string Telefono { get; set; }
        public int Asignaturaid { get; set; }
        [JsonIgnore]
        public Asignatura Asignatura { get; set; }


    }
}
