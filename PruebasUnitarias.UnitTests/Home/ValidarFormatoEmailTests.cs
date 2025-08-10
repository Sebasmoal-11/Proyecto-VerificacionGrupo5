using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TiendaVirtualMVC.Models;

namespace TiendaVirtualMVC.Tests
{
    [TestClass]
    public class ValidarFormatoEmailTests
    {
        [DataTestMethod]
        [DataRow("usuario@example.com", true)]
        [DataRow("usuario@dominio", false)]
        [DataRow("usuario.com", false)]
        [DataRow("usuario@dominio.com", true)]
        public void ValidarFormatoEmail(string email, bool esValidoEsperado)
        {
            var modelo = new ContactFormModel { Email = email };
            var contexto = new ValidationContext(modelo) { MemberName = "Email" };
            var resultados = new List<ValidationResult>();
            Validator.TryValidateProperty(modelo.Email, contexto, resultados);

            bool esValido = resultados.Count == 0;
            Assert.AreEqual(esValidoEsperado, esValido);
        }
    }
}
// Prueba unitaria 4