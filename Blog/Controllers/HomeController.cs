using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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