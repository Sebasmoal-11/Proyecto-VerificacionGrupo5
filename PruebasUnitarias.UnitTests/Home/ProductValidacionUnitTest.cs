using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiendaVirtualMVC.Models;
using TiendaVirtualMVC.Rules;

namespace PruebasUnitarias.UnitTests.Product
{
    [TestClass]
    public class ProductUnitTest
    {
        private (bool, string) esperado;
        private (bool, string) obtenido;
        private TiendaVirtualMVC.Models.Product producto;

        [TestMethod]
        [TestCategory("Requerimiento 3: nombre vacío")] //Requerimiento 3
        public void nombreVacio_devuelveError()
        {
            producto = new TiendaVirtualMVC.Models.Product()
            {
                Name = "",
                Description = "Zapatos deportivos talla 42",
                Price = 59.99m
            };

            esperado = (false, "El nombre es obligatorio");
            obtenido = RulesProduct.productoEsValido(producto);

            Assert.AreEqual(esperado, obtenido);
        }
    }
}
