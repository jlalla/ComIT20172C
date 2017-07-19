using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticulosController : Controller
    {
        BlogContext db = new BlogContext();

        [HttpPost]
        public ActionResult Crear(string titulo, string texto)
        {
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.Titulo = titulo;
            nuevoArticulo.Texto = texto;
            nuevoArticulo.FechaCreacion = DateTime.Now;
            nuevoArticulo.Destacado = false; //TODO
            nuevoArticulo.Autor = db.Usuarios.First(u => u.Mail == "julieta@gmail.com"); //"julieta@gmail.com"; //TODO: Poner usuario logueado

            db.Articulos.Add(nuevoArticulo);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}