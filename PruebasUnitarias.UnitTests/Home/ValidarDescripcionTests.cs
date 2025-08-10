using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TiendaVirtualMVC.Models;

namespace TiendaVirtualMVC.Tests
{
    [TestClass]
    public class ValidarDescripcionTests
    {
        [TestMethod]
        public void Description_NoDebePermitirMasDe500Caracteres()
        {
            var producto = new Product
            {
                Description = new string('a', 501)
            };

            var contexto = new ValidationContext(producto) { MemberName = "Description" };
            var resultados = new List<ValidationResult>();
            Validator.TryValidateProperty(producto.Description, contexto, resultados);

            Assert.IsTrue(resultados.Any(r => r.ErrorMessage != null && r.ErrorMessage.Contains("500")),
                "La validación no detectó que la descripción excede los 500 caracteres");
            Assert.IsTrue(resultados.Any(r => r.ErrorMessage != null && r.ErrorMessage.Contains("500")),
                "La validación no detectó que la descripción excede los 500 caracteres");
        }
    }
}
//Prueba unitaria 7