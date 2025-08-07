using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Audits;
using Selenium.TestAutomatizadas.Test.Requerimiento07;
using Selenium.TestAutomatizadas.Test.Requerimiento08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.TestAutomatizadas
{
    class Program
    {

        static void Main(string[] args)
        {
            string rutaWindows = @"F:\Sebastian\U\Cursos actuales\Verificacion y validacion de software\Proyecto\Pagina Web\index.html"; //aca ponen su ruta donde tienen guardada la pagina web  de Visual studio code
            string rutaUrl = new Uri(rutaWindows).AbsoluteUri;

            Console.WriteLine(rutaUrl);

            // Aquí agregan se agregan segun los requerimientos de esta manera

            //var nombre de la variable = new nombre de la clase de la prueba(rutaUrl);
            //Nombre de la variable.Nombre del requirimiento();

            // Ejecutar todas las pruebas 
            var pruebaDescripcionProducto = new ValidarDescripcionProductoTest(rutaUrl);
            pruebaDescripcionProducto.Requerimiento07();

            var pruebaDatosProducto = new ValidarDatosInvalidosProductoTest(rutaUrl);
            pruebaDatosProducto.Requerimiento08();

        }
    }
}