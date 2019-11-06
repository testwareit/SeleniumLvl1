using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Lesson1ShowDriver
    {
        IWebDriver driver;

        [Test]
        public void Sample_1_OpenBrowserAndKill()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(),chromeOptions);

            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Sample_2_OpenWebpage()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(),chromeOptions);

            driver.Navigate().GoToUrl("https://google.com");

            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Sample_3_MakeFullScreen()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://google.com");

            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Sample_4_HardcodedSize()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);

            driver.Manage().Window.Size = new System.Drawing.Size(400, 800);

            driver.Navigate().GoToUrl("https://google.com");

            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Sample_5_GoBack()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(1000);

            driver.Navigate().Back();
            Thread.Sleep(1000);

            driver.Quit();
        }

        [Test]
        public void Sample_6_Refresh()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(1000);

            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            driver.Quit();
        }

        [Test]
        public void Sample_7_PageSource()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(1000);

            var source = driver.PageSource;

            driver.Quit();
        }

        [Test]
        public void Sample_8_Close()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(1000);

            driver.Close();
            driver.Quit();
        }
    }
}