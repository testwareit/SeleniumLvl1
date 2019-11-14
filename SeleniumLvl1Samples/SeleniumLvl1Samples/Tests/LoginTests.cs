using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumLvl1Samples.WPJobBoardPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SeleniumLvl1Samples.Tests
{
    [TestFixture]
    public class LoginTests
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
        public void LoginPositive()
        {
            driver.Navigate().GoToUrl("https://demo.wpjobboard.net/wp-login.php");

            WPLoginPage wPLoginPage = new WPLoginPage(driver);

            wPLoginPage.LogIn("user", "user");
        }
    }
}