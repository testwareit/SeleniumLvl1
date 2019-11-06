using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Lesson2WebElement
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Sample_1_GetElement()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");
        }

        [Test]
        public void Sample_2_GetElements()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");

            var buttons = driver.FindElements(By.XPath("//input[@name='btnK']"));
            var buttonSearch = buttons.First(w => w.Displayed == true);

            buttonSearch.Click();
        }
    }
}