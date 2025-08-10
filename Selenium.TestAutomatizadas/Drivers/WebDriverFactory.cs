using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.TestAutomatizadas.Drivers
{
    /// <summary>
    /// Fábrica de WebDrivers.
    /// Centraliza la creación y configuración del navegador (Chrome) para TODAS las pruebas UI.
    /// Ventajas:
    ///  - No repetimos configuración en cada test
    ///  - Cambiamos opciones en un solo lugar (headless, tamaño, timeouts, etc.)
    ///  - Facilita cambiar de navegador a futuro (Edge, Firefox) si se desea
    /// </summary>
    public static class WebDriverFactory
    {
        /// <summary>
        /// Crea y devuelve un IWebDriver de Chrome con opciones estándar para pruebas.
        /// Parámetro:
        ///  - headless: true = sin ventana (útil en CI), false = con ventana (útil en desarrollo)
        /// </summary>
        public static IWebDriver CreateChrome(bool headless = false)
        {
            var options = new ChromeOptions();

            //Modo "headless" (sin UI) para pipelines/CI o servidores sin entorno gráfico.
            if (headless)
            {
                // "--headless=new" = headless moderno de Chrome (mejor rendimiento/compatibilidad)
                options.AddArgument("--headless=new");
                // Fijamos tamaño de ventana para evitar "element not clickable at point" por viewport pequeño
                options.AddArgument("--window-size=1920,1080");
            }

            //Preferimos abrir maximizado en modo no headless (más estable para encontrar/clicar elementos)
            options.AddArgument("--start-maximized");

            //Flags típicos para entornos de automatización (algunos evitan warnings en ciertos hosts)
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            // Habilita la recopilación de logs del navegador (consola JS)
            //Así podemos leer errores SEVERE en las pruebas (p.ej. HomePage.HasNoClientErrors()).
            options.SetLoggingPreference(LogType.Browser, OpenQA.Selenium.LogLevel.All);

            // Crea la instancia de ChromeDriver con las opciones anteriores.
            //Nota: el paquete NuGet Selenium.WebDriver.ChromeDriver copia "chromedriver.exe" al bin automáticamente.
            var driver = new ChromeDriver(options);

            //Implicit Wait global (pequeño): le da hasta 2s a Selenium para encontrar elementos.
            //Seguimos usando esperas explícitas (WebDriverWait) para eventos concretos (cargas, visibilidad, etc.).
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            return driver;
        }
    }
}

