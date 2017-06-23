using System;
using System.Collections.Generic;
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
    }
}