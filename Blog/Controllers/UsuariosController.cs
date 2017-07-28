using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsuariosController : Controller
    {

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            using (BlogContext db = new BlogContext())
            {
                Usuario usuario = 
                    db.Usuarios.FirstOrDefault(u => u.Mail == email && u.Password == password);
                if(usuario != null)
                {
                    //login correcto
                    Session["UsuarioLogueado"] = usuario;
                }
                else
                {
                    //o no existe o está mal contraseña
                    TempData["Error"] = "El usuario no existe o está mal la contraseña.";
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            //Session["UsuarioLogueado"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MiPerfil()
        {
            if (Session["UsuarioLogueado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Usuario usuario = (Usuario)Session["UsuarioLogueado"];
            return View(usuario);
        }
    }
}