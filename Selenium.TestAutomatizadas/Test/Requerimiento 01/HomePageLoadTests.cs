using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Selenium.TestAutomatizadas.Pages;

namespace Selenium.TestAutomatizadas.Test.Caso01_Home
{
    [TestClass]
    [TestCategory("UI"), TestCategory("Home")]
    public class HomePageLoadTests : BaseTest
    {
        [DataTestMethod]
        [DataRow("anon")]
        [DataRow("userA")]
        [DataRow("userB")]
        public void Home_Should_Load_In_Under_3s_WithoutErrors(string userKey)
        {
            var home = new HomePage(Driver, BaseUrl);

            // TODO opcional: si tu flujo requiere login por usuario, hazlo aquí según userKey

            var sw = Stopwatch.StartNew();
            home.Go();
            var loaded = home.IsLoaded();
            sw.Stop();

            Assert.IsTrue(loaded, "La página de inicio no cargó correctamente.");
            Assert.IsTrue(sw.Elapsed.TotalSeconds <= 3.0, $"La página tardó {sw.Elapsed.TotalSeconds:0.00}s (>3s).");
            Assert.IsTrue(home.HasNoClientErrors(), "Se detectaron errores SEVERE en la consola del navegador.");
        }
    }
}