using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    /// <summary>
    /// Representa a la entidad artículo del blog
    /// </summary>
    public class Articulo
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public Usuario Autor { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}