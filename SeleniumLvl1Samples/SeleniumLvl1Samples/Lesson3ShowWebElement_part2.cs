using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
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

            var alertButton = driver.FindElement(By.XPath("//button[contains(text(),'Alert')]"));
            alertButton.Click();
            driver.SwitchTo().Alert().Accept();

            var confirmButton = driver.FindElement(By.XPath("//button[contains(text(),'Confirm')]"));
            confirmButton.Click();
            driver.SwitchTo().Alert().Dismiss();

            var promptButton = driver.FindElement(By.XPath("//button[contains(text(),'Prompt')]"));
            promptButton.Click();

            var alert = driver.SwitchTo().Alert();

            alert.SendKeys("testKeys");
            alert.Accept();
        }

        [Test]
        public void Sample_14_SwitchToFrame()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/iframe");

            driver.SwitchTo().Frame("mce_0_ifr");
            driver.FindElement(By.TagName("p")).SendKeys("test");

            driver.FindElement(By.TagName("p")).Clear();
        }

        [Test]
        public void Sample_15_SwitchToWindow()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/windows");

            driver.FindElement(By.LinkText("Click Here"));
        }

        [Test]
        public void Sample_16_Hover()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/hovers");

            var elements = driver.FindElements(By.ClassName("figure"));

            foreach(var element in elements)
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Build().Perform();
            }
        }

        //[Test]
        //public void Sample_17_DragAndDrop()
        //{
        //    driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");

        //    var elements = driver.FindElements(By.XPath("//div[contains(@id,'column-')]"));

        //    Actions actions = new Actions(driver);
        //    //actions.DragAndDrop(elements[0], elements[1]).Build().Perform();

        //    actions.MoveToElement(elements[0])
        //        .ClickAndHold(elements[0])
        //        .MoveByOffset(1, 0).MoveToElement(elements[1]).MoveByOffset(1, 0)
        //        .Release().Perform();
        //}

        [Test]
        public void Sample_18_ContextMenu()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/simple_context_menu.html");

            Actions actions = new Actions(driver);
            actions.ContextClick(driver.FindElement(By.XPath("//span[text()='right click me']")))
                .Build().Perform();

            driver.FindElement(By.XPath("//span[text()='Edit']")).Click();
        }

        [Test]
        public void Sample_19_ImplicitWait()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dynamic_loading/2");

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElement(By.XPath("//*[@id='start']/button")).Click();

            var elementFinish = driver.FindElement(By.XPath("//*[@id='finish']/h4"));
        }

        [Test]
        public void Sample_20_ExplicitWait()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dynamic_loading/1");

            driver.FindElement(By.XPath("//*[@id='start']/button")).Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //var elementFinish = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='finish']/h4")));
            //var elementFinish = wait.Until(w=>w.FindElement(By.XPath("//*[@id='finish']/h4")).Displayed);
            //var elementFinish = wait.Until(w=>w.FindElement(By.XPath("//*[@id='finish']/h4")));
        }

        [Test]
        public void Sample_21_Javascript()
        {
            driver.Navigate().GoToUrl("https://testware.it/courses/sw1/sample6Javascript.html");

            //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;

            var result = ((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active;");

            var element = driver.FindElement(By.Id("elementToBeHidden"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.display='none'", element);
        }
    }
}