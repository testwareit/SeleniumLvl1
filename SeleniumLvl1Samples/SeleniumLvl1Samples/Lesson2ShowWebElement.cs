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
        public void Sample_1_GetElement_ElementNotFound()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='qqwerty']"));
            search.SendKeys("selenium");
        }

        [Test]
        public void Sample_2_GetElement_Text()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");

            IWebElement titleElement = driver.FindElement(By.TagName("h1"));
            var text = titleElement.Text;

            Assert.AreEqual("Welcome to the-internet", text);
            StringAssert.Contains("Welcome", text);
        }

        [Test]
        public void Sample_3_GetElement_AddRemove()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");

            //var addButton = driver.FindElement(By.)
        }

        [Test]
        public void Sample_4_GetElements_AddRemove()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
        }

        [Test]
        public void Sample_4_GetElements_AddRemove_Negative()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
        }
        [Test]
        public void Sample_5_GetElements_Google()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");

            var buttons = driver.FindElements(By.XPath("//input[@name='btnK']"));
            var buttonSearch = buttons.First(w => w.Displayed == true);

            buttonSearch.Click();
        }

        [Test]
        public void Sample_6_GetElement_Clear()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");

            search.Clear();
        }

        [Test]
        public void Sample_7_GetElement_Submit()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");

            search.Submit();
        }

        [Test]
        public void Sample_8_GetElement_GetAttribute()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
            search.SendKeys("selenium");
        }

        [Test]
        public void Sample_9_GetElement_GetCssValue()
        {
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement search = driver.FindElement(By.XPath("//input[@name='q']"));
        }

        [Test]
        public void Sample_10_GetElement_Enabled_Displayed()
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
    }
}