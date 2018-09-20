using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace ConversaoGalaoLitro.Tests
{
    [TestClass]
    public class TestesSelenium
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void Initialize()
        {
            appURL = "https://meetup-selenium.azurewebsites.net/";
            //appURL = "http://localhost:50237/";

            string browser = "Chrome";

            switch (browser)
            {
                case "Chrome":
                    //driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                    break;
                case "IE":
                    driver = new InternetExplorerDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                    break;
                default:
                    driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                    break;
            }
        }

        [TestMethod]
        [DataRow(1, 3.7854)]
        [DataRow(2, 7.5708)]
        [DataRow(3, 11.3562)]
        [TestCategory("TestesSelenium")]
        public void CalcularGaloesParaLitro_Selenium(double galoes, double resultadoEsperado)
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.Name("txtGalao")).SendKeys(galoes.ToString());
            driver.FindElement(By.Name("btnSubmit")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until((d) => d.FindElement(By.Id("lblResultado")) != null);
            var resultado = Convert.ToDouble(driver.FindElement(By.Id("lblResultado")).Text);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestCleanup()]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
