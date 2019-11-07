using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Linq;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Lesson3ShowWebElement_part2
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-blink-features='BlockCredentialedSubresources'");
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
        public void Sample_08_GetElement_GetAttribute()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");
        }

        [Test]
        public void Sample_09_GetElement_GetCssValue()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
        }


        [Test]
        public void Sample_11_GetElement_Checkboxes()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
        }

        [Test]
        public void Sample_12_GetElement_Dropdown()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");

        }


        /// <summary>
        /// Show switchto
        /// </summary>
        [Test]
        public void Sample_13_Alerts()
        {
            ///user and pass: admin
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");

            var alert = driver.FindElement(By.XPath("//button[contains(text(),'Alert')]"));
            alert.Click();



        }

        [Test]
        public void Sample_14_BasicAuth()
        {
            ///user and pass: admin
            driver = new FirefoxDriver(Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/basic_auth");

            driver.SwitchTo().Alert().SetAuthenticationCredentials("admin", "admin");
            driver.SwitchTo().Alert().Accept();

        }
    }
}