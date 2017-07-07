using Blog.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Articulo> articulos = new List<Articulo>();

            Articulo articulo1 = new Articulo();
            articulo1.Titulo = "Se fue Pavone";
            articulo1.Texto = "El jugador no renovó su contrato. Se va a Estudiantes";
            articulo1.Destacado = true;
            articulo1.Imagen = "/Content/images/pavone.png";
            articulos.Add(articulo1);

            Articulo articulo2 = new Articulo();
            articulo2.Titulo = "Empatamos";
            articulo2.Texto = "Empatamos con el cervecero...";
            articulo2.Destacado = true;
            articulo2.Imagen = "/Content/images/quilmes.jpg";
            articulos.Add(articulo2);

            Articulo articulo3 = new Articulo();
            articulo3.Titulo = "Ganamos el \"clásico\"";
            articulo3.Texto = "Vélez le ganó a Tigre de local...";
            articulo3.Destacado = true;
            articulo3.Imagen = "/Content/images/tigre.jpg";
            articulos.Add(articulo3);

            Articulo articulo4 = new Articulo();
            articulo4.Titulo = "Otra derrota en casa";
            articulo4.Texto = "Vélez perdió con Belgrano de local...";
            articulo4.Destacado = true;
            articulo4.Imagen = "/Content/images/belgrano.jpg";
            articulos.Add(articulo4);

            Articulo articulo5 = new Articulo();
            articulo5.Titulo = "Otra derrota de visitante";
            articulo5.Texto = "Vélez perdió con Lanus.";
            articulos.Add(articulo5);

            Articulo articulo6 = new Articulo();
            articulo6.Titulo = "Otra noticia positiva";
            articulo6.Texto = "Vélez.";
            articulos.Add(articulo6);

            Articulo articulo7 = new Articulo();
            articulo7.Titulo = "Otra noticia positiva";
            articulo7.Texto = "Vélez";
            articulos.Add(articulo7);

            Articulo articulo8 = new Articulo();
            articulo8.Titulo = "Otra noticia positiva";
            articulo8.Texto = "Vélez";
            articulos.Add(articulo8);

            ViewBag.Articulos = articulos;
            return View();
        }

        public ActionResult AcercaDe()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Contacto(string nombre, string email, string consulta)
        {
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            //clienteSmtp.Host = "smtp.gmail.com";
            //clienteSmtp.Port = 587;
            clienteSmtp.Credentials = new NetworkCredential("testcomunidadit@gmail.com", "pruebamail201706");
            clienteSmtp.EnableSsl = true;

            //mail para el dueño de la aplicación
            MailMessage mensajeParaAplicacion = new MailMessage();
            mensajeParaAplicacion.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
            mensajeParaAplicacion.To.Add("testcomunidadit@gmail.com");
            mensajeParaAplicacion.Subject = "Te contactaron del Blog";
            mensajeParaAplicacion.Body = nombre + " (" + email + ") te contactó desde la aplicación. Te dejó la siguiente consulta: " + consulta;

            clienteSmtp.Send(mensajeParaAplicacion);

            //mail para el usuario
            MailMessage mensajeParaUsuario = new MailMessage();
            mensajeParaUsuario.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
            mensajeParaUsuario.To.Add(email);
            mensajeParaUsuario.Subject = "Gracias por contactarte con el Blog!";
            mensajeParaUsuario.IsBodyHtml = true;
            mensajeParaUsuario.Body = "Hola " + nombre + ", <br>Gracias por contactarte con nosotros!<br>Tu mensaje fue: <b>" + consulta + "</b><br>Saludos!!!!<br><b>El equipo del blog</b><br><img src=\"http://statictycf5b.tycsports.com/sites/default/files/styles/landscape_642_366/public/nota_periodistica/16-02-2016_buenos_aires_mariano_pavone_festeja.jpg\">";

            clienteSmtp.Send(mensajeParaUsuario);

            //return RedirectToAction("Index");
            ViewBag.Nombre = nombre;
            return View();
        }
    }
}