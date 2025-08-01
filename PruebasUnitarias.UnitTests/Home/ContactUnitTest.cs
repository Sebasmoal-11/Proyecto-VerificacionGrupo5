using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PruebasUnitarias.UnitTests.Home
{
    [TestClass]
    public class ContactUnitTest
    {
        private (bool, string) resultadoEsperado;
        private (bool, string) resultadoObtenido;
        private Contact contact;

        [TestMethod]
        [TestCategory("Probar la validación de los campos del formulario de contacto")] //nombre del requerimiento 9

        public void losCamposSonValidos_SonValidos()
        {
            this.contact = new Contact();
            {

            }
        }


    }
}
