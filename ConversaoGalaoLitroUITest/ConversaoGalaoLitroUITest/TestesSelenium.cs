using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConversaoGalaoLitroUITests
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
            appURL = Environment.GetEnvironmentVariable("APP_URL");
            //appURL = "http://localhost:50237/";

            string browser = "Chrome";

            switch (browser)
            {
                case "Chrome":
                    //driver = new ChromeDriver(@"C:\Selenium\ChromeDriver\");
                    driver = new ChromeDriver();
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

            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            string fileName = Directory.GetCurrentDirectory() + "Screenshot_" + TestContext.TestName + DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".png";
            screenShot.SaveAsFile((fileName), ScreenshotImageFormat.Png);
            TestContext.AddResultFile(fileName);

            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestCleanup()]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
