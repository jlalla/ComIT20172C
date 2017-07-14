using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    /// <summary>
    /// Representa a la entidad artículo del blog
    /// </summary>
    [Table("Articulos")]
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public bool Destacado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Usuario Autor { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}