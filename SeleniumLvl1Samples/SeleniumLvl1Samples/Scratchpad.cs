using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Scratchpad
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

        
        public void login()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");

            var login = driver.FindElement(By.Id("username"));
            login.SendKeys("tomsmith");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("SuperSecretPassword!");

            driver.FindElement(By.TagName("button")).Click();


            var logoutButton = driver.FindElement(By.XPath("//a[@href='/logout']"));

            Assert.IsTrue(logoutButton.Displayed);
        }

        //https://testware.it/courses/sw1/sample1FindElement.html
        //https://testware.it/courses/sw1/sample1FindElementEnabledDisplayed.html
        //https://testware.it/courses/sw1/sample2FindElements.html
        //https://testware.it/courses/sw1/sample3FindElementsPassword.html
        //https://testware.it/courses/sw1/sample4FindElementsMaskedPassword.html
    }
}