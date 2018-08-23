using ConversaoGalaoLitro.Dominio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace ConversaoGalaoLitro.Testes
{
    public class TestesSelenium : IDisposable
    {
        private IWebDriver driver;
        private string appURL;

        public TestesSelenium()
        {
            appURL = "http://localhost:50237/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        [Theory]
        [InlineData(1, 3.7854)]
        [InlineData(2, 7.5708)]
        [InlineData(3, 11.3562)]
        [Trait("Category", "TestesSelenium")]
        public void CalcularGaloesParaLitro(double galoes, double resultadoEsperado)
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.Name("txtGalao")).SendKeys(galoes.ToString());
            driver.FindElement(By.Name("btnSubmit")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until((d) => d.FindElement(By.Id("lblResultado")) != null);
            var resultado = Convert.ToDouble(driver.FindElement(By.Id("lblResultado")).Text);
            Assert.Equal(resultadoEsperado, resultado);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
