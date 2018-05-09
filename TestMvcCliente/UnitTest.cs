using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMvcCliente
{
    [TestClass]
    public class UnitTest
    {
        private IWebDriver driverChrome;

        [TestInitialize]
        public void TestSetup()
        {
            driverChrome = new ChromeDriver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driverChrome.Quit();
        }

        [TestMethod]
        [DataRow("http://localhost:65052/Student/Create")]
        public void Add_Student_MVC_Chrome(string url)
        {
            // Abrimos conexion browser Chrome
            driverChrome.Navigate().GoToUrl(url);
            driverChrome.Manage().Window.Maximize();

            // Insertamos datos en la vista create
            driverChrome.FindElement(By.Id("Name")).SendKeys("Gratonell");
            driverChrome.FindElement(By.Id("Apellidos")).SendKeys("Raton");
            driverChrome.FindElement(By.Id("Dni")).SendKeys("88888876A");
            driverChrome.FindElement(By.Id("FechaNacimiento")).SendKeys("10/01/1998");
            driverChrome.FindElement(By.Id("BtnCreate")).Click();

            // assert lista students
            WebDriverWait wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(15));
            IWebElement navList = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("tableStudent"));
            });
        }
    }
}
