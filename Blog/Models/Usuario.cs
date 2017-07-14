using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Usuario
    {
        [Key]
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Bio { get; set; }
    }
}