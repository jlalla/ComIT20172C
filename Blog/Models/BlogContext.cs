using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        /// <summary>
        /// Llamamos al constructor de DbContext y le pasamos
        /// el nombre de la cadena de conexión en el web.config
        /// </summary>
        public BlogContext() : base("name=BlogContext")
        {

        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}