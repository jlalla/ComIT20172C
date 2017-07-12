using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Prueba1()
        {
            return "Hola";
        }

        public string PruebaSuma(int operando1, int operando2)
        {
            int suma = operando1 + operando2;
            return suma.ToString();
        }

        public string PruebaDivision(decimal dividendo, decimal divisor)
        {
            if (divisor == 0)
            {
                return "No podés dividir por cero.";
            }

            decimal resultado = dividendo / divisor;
            return resultado.ToString();
        }        

        /// <summary>
        /// Método de prueba para hacer una multiplicación a través de una acción
        /// </summary>
        /// <param name="operando1">primer operando</param>
        /// <param name="operando2"></param>
        /// <returns></returns>
        public string PruebaMultiplicacion(decimal operando1, decimal operando2)
        {
            decimal resultado = 0;
            for(int i = 1; i <= operando2; i++)
            {
                resultado += operando1;
            }            
            return resultado.ToString();
        }

        public string PruebaEF()
        {
            using (BlogContext db = new Models.BlogContext())
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Mail = "larala@gmail.com";
                nuevoUsuario.Nombre = "Lara La";
                nuevoUsuario.Password = "123456";
                nuevoUsuario.Bio = "un poco sobre mi...";

                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();
            }
            return "listo";
        }

        public string PruebaAdoNet()
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Mail = "laralalla@gmail.com";
            nuevoUsuario.Nombre = "Lara Lalla";
            nuevoUsuario.Password = "123456";
            nuevoUsuario.Bio = "un poco sobre mi...";

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogContext"].ConnectionString))
            {
                conexion.Open();
                using (SqlCommand sentencia = conexion.CreateCommand())
                {
                    sentencia.CommandText = "INSERT INTO Usuarios (Mail, Nombre, Password, Bio) VALUES(@Mail, @Nombre, @Password, @Bio)";
                    sentencia.Parameters.AddWithValue("@Mail", nuevoUsuario.Mail);
                    sentencia.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                    sentencia.Parameters.AddWithValue("@Password", nuevoUsuario.Password);
                    sentencia.Parameters.AddWithValue("@Bio", nuevoUsuario.Bio);
                    sentencia.ExecuteNonQuery();
                }
                //conexion.Close(); //no es necesario por el using
            }

            return "listo";
        }

        public string PruebaEFConsulta()
        {
            using (BlogContext db = new Models.BlogContext())
            {
                //Usuario usuario = db.Usuarios.First();
                Usuario usuario = db.Usuarios.First(u => u.Mail == "julieta@gmail.com");
            }
            return "listo";
        }

        public string PruebaEFConsultaTodos()
        {
            using (BlogContext db = new Models.BlogContext())
            {                
                List<Usuario> usuarios = db.Usuarios.ToList();

                return "listo";
            }            
        }

        public string PruebaAdoNetConsulta()
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BlogContext"].ConnectionString))
            {
                conexion.Open();
                using (SqlCommand sentencia = conexion.CreateCommand())
                {
                    sentencia.CommandText = "select * from usuarios where mail = 'julieta@gmail.com'";

                    using (SqlDataReader reader = sentencia.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Usuario usuario = new Models.Usuario();
                            usuario.Mail = reader["Mail"].ToString();
                            usuario.Nombre = reader["Nombre"].ToString();
                            usuario.Password = reader["Password"].ToString();
                            usuario.Imagen = reader["Imagen"].ToString();
                            usuario.Bio = reader["Bio"].ToString();
                        }
                    }                    
                }
            }

            return "listo";
        }
    }
}