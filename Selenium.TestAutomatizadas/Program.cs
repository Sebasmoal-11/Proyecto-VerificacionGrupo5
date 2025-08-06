
namespace Selenium.TestAutomatizadas
{
    class Program
    {

        static void Main(string[] args)
        {
            string rutaWindows = @""; //aca ponen su ruta donde tienen guardada la pagina web
            string rutaUrl = new Uri(rutaWindows).AbsoluteUri;

            Console.WriteLine(rutaUrl);

            string urlFormulario = rutaUrl;

            var auto = new FormularioTest(urlFormulario);

            auto.Ejecutar();
        }
    }
}
