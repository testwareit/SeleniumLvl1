using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Lesson2ShowWebElement
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
            driver.Navigate().GoToUrl("https://testware.it/courses/sw1/sample1.html");

            IWebElement buttonDisplayDate = driver.FindElement(By.Id("showDate"));
            buttonDisplayDate.Click();

            IWebElement txtDisplayedDate = driver.FindElement(By.Id("demo"));
        }
    }
}